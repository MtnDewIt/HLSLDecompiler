namespace HLSLDecompiler.HLSL
{
    public class PowerOperation : Operation
    {
        public PowerOperation(HLSLTreeNode value, HLSLTreeNode power)
        {
            AddInput(value);
            AddInput(power);
        }

        public HLSLTreeNode Value => Inputs[0];
        public HLSLTreeNode Power => Inputs[1];

        public override string Mnemonic => "pow";
    }
}
