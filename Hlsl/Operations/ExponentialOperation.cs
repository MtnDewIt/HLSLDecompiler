namespace HLSLDecompiler.HLSL
{
    public class ExponentialOperation : ConsumerOperation
    {
        public ExponentialOperation(HLSLTreeNode value)
        {
            AddInput(value);
        }

        public override string Mnemonic => "exp";
    }
}
