using System.Collections.Generic;

namespace HLSLDecompiler.HLSL
{
    public class NormalizeOutputNode : HLSLTreeNode, IHasComponentIndex
    {
        public NormalizeOutputNode(IEnumerable<HLSLTreeNode> inputs, int componentIndex)
        {
            foreach (HLSLTreeNode input in inputs)
            {
                AddInput(input);
            }

            ComponentIndex = componentIndex;
        }

        public int ComponentIndex { get; }
    }
}
