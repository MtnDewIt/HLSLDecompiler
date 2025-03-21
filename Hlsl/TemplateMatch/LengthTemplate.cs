using HLSLDecompiler.Operations;
using System.Collections.Generic;

namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public class LengthTemplate : IGroupTemplate
    {
        public IGroupContext Match(HLSLTreeNode node)
        {
            if (node is SquareRootOperation sqrt && sqrt.Value is DotProductOperation dot)
            {
                if (NodeGrouper.AreNodesEquivalent(dot.X, dot.Y))
                {
                    return new LengthContext(new GroupNode(new List<HLSLTreeNode>(dot.X.Inputs).ToArray()));
                }
            }
            return null;
        }

        public HLSLTreeNode Reduce(HLSLTreeNode node, IGroupContext groupContext)
        {
            var lengthContext = groupContext as LengthContext;
            return new LengthOperation(lengthContext.Value);
        }
    }
}
