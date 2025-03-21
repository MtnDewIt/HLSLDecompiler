namespace HLSLDecompiler.HLSL
{
    public class MinimumOperation : Operation
    {
        public MinimumOperation(HLSLTreeNode value1, HLSLTreeNode value2)
        {
            AddInput(value1);
            AddInput(value2);
        }

        public HLSLTreeNode Value1 => Inputs[0];
        public HLSLTreeNode Value2 => Inputs[1];

        public override string Mnemonic => "min";
    }
}
