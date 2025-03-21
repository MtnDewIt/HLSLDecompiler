using HLSLDecompiler.Operations;

namespace HLSLDecompiler.HLSL.TemplateMatch
{
    // 4 by 4 dot product has a pattern of:
    // #1  dot3(abc, xyz) + dw
    // #2  dw + dot3(abc, xyz)
    public class DotProduct4Template : IGroupTemplate
    {
        private TemplateMatcher _templateMatcher;
        private bool allowMatrixColumn = true;

        public DotProduct4Template(TemplateMatcher templateMatcher)
        {
            _templateMatcher = templateMatcher;
        }

        public IGroupContext Match(HLSLTreeNode node)
        {
            return MatchDotProduct4(node);
        }

        private DotProductContext MatchDotProduct4(HLSLTreeNode node)
        {
            if (!(node is AddOperation addition))
            {
                return null;
            }

            MultiplyOperation dw;
            if (addition.Addend1 is DotProductOperation dot && dot.X.Length == 3)
            {
                dw = addition.Addend2 as MultiplyOperation;
                if (dw == null)
                {
                    return null;
                }
            }
            else
            {
                dot = addition.Addend2 as DotProductOperation;
                if (dot == null || dot.X.Length != 3)
                {
                    return null;
                }

                dw = addition.Addend1 as MultiplyOperation;
                if (dw == null)
                {
                    return null;
                }
            }

            HLSLTreeNode c = dot.X.Inputs[2];
            HLSLTreeNode d = dw.Factor1;
            if (_templateMatcher.CanGroupComponents(c, d, allowMatrixColumn))
            {
                HLSLTreeNode a = dot.X.Inputs[0];
                HLSLTreeNode b = dot.X.Inputs[1];
                HLSLTreeNode x = dot.Y.Inputs[0];
                HLSLTreeNode y = dot.Y.Inputs[1];
                HLSLTreeNode z = dot.Y.Inputs[2];
                HLSLTreeNode w = dw.Factor2;
                if (allowMatrixColumn && _templateMatcher.SharesMatrixColumnOrRow(c, d))
                {
                    // If one of the arguments is a matrix, allow the other argument to be arbitrary.
                    return new DotProductContext(new GroupNode(a, b, c, d), new GroupNode(x, y, z, w));
                }
                if (_templateMatcher.CanGroupComponents(z, w, allowMatrixColumn))
                {
                    return new DotProductContext(new GroupNode(a, b, c, d), new GroupNode(x, y, z, w));
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
