namespace HLSLDecompiler.HLSL
{
    public class TempAssignmentNode : HLSLTreeNode, IHasComponentIndex
    {
        public TempAssignmentNode(TempVariableNode tempVariable, HLSLTreeNode value)
        {
            AddInput(value);
            TempVariable = tempVariable;
        }

        public TempVariableNode TempVariable { get; }

        public HLSLTreeNode Value => Inputs[0];
        public int ComponentIndex => TempVariable.RegisterComponentKey.ComponentIndex;

        public bool IsReassignment { get; set; } = false;

        public override string ToString()
        {
            return $"{TempVariable} = {Value}";
        }
    }
}
