namespace HLSLDecompiler.HLSL
{
    public class GroupNode : HLSLTreeNode
    {
        public GroupNode(params HLSLTreeNode[] components)
        {
            foreach (HLSLTreeNode component in components)
            {
                AddInput(component);
            }
        }

        public int Length => Inputs.Count;

        public HLSLTreeNode this[int index]
        {
            get => Inputs[index];
            set => Inputs[index] = value;
        }

        public override string ToString()
        {
            return $"({string.Join(",", Inputs)})";
        }
    }
}
