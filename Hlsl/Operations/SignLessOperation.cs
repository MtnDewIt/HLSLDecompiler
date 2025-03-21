namespace HLSLDecompiler.HLSL
{
    public class SignLessOperation : Operation
    {
        public SignLessOperation(HLSLTreeNode value1, HLSLTreeNode value2)
        {
            AddInput(value1);
            AddInput(value2);
        }

        public override string Mnemonic => "slt";
    }
}
