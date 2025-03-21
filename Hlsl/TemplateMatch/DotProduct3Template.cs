using HLSLDecompiler.Operations;

namespace HLSLDecompiler.HLSL.TemplateMatch
{
    // 3 by 3 dot product has a pattern of:
    // #1  dot(ab, xy) + c*z
    // #2  c*z + dot(ab, xy)
    public class DotProduct3Template : IGroupTemplate
    {
        private TemplateMatcher _templateMatcher;
        private bool allowMatrixColumn = true;

        public DotProduct3Template(TemplateMatcher templateMatcher)
        {
            _templateMatcher = templateMatcher;
        }

        public IGroupContext Match(HLSLTreeNode node)
        {
            return MatchDotProduct3(node);
        }

        private DotProductContext MatchDotProduct3(HLSLTreeNode node)
        {
            if (!(node is AddOperation addition))
            {
                return null;
            }

            MultiplyOperation cz;
            if (addition.Addend1 is DotProductOperation dot && dot.X.Length == 2)
            {
                cz = addition.Addend2 as MultiplyOperation;
                if (cz == null)
                {
                    return null;
                }
            }
            else
            {
                dot = addition.Addend2 as DotProductOperation;
                if (dot == null || dot.X.Length != 2)
                {
                    return null;
                }

                cz = addition.Addend1 as MultiplyOperation;
                if (cz == null)
                {
                    return null;
                }
            }

            HLSLTreeNode b = dot.X.Inputs[1];
            HLSLTreeNode c = cz.Factor1;
            if (_templateMatcher.CanGroupComponents(b, c, allowMatrixColumn))
            {
                HLSLTreeNode a = dot.X.Inputs[0];
                HLSLTreeNode x = dot.Y.Inputs[0];
                HLSLTreeNode y = dot.Y.Inputs[1];
                HLSLTreeNode z = cz.Factor2;
                if (allowMatrixColumn && _templateMatcher.SharesMatrixColumnOrRow(a, b))
                {
                    // If one of the arguments is a matrix, allow the other argument to be arbitrary.
                    return new DotProductContext(new GroupNode(a, b, c), new GroupNode(x, y, z));
                }
                if (_templateMatcher.CanGroupComponents(y, z, allowMatrixColumn))
                {
                    return new DotProductContext(new GroupNode(a, b, c), new GroupNode(x, y, z));
                }
            }

            return null;
        }

        public HLSLTreeNode Reduce(HLSLTreeNode node, IGroupContext groupContext)
        {
            var dotProductContext = groupContext as DotProductContext;
            return new DotProductOperation(dotProductContext.Value1, dotProductContext.Value2);
        }
    }
}
