namespace HLSLDecompiler.HLSL
{
    public class SignGreaterOrEqualOperation : Operation
    {
        public SignGreaterOrEqualOperation(HLSLTreeNode value1, HLSLTreeNode value2)
        {
            AddInput(value1);
            AddInput(value2);
        }

        public override string Mnemonic => "sge";
    }
}
