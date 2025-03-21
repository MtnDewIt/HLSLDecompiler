namespace HLSLDecompiler.HLSL
{
    public class PartialDerivativeXOperation : ConsumerOperation
    {
        public PartialDerivativeXOperation(HLSLTreeNode value)
        {
            AddInput(value);
        }

        public override string Mnemonic => "ddx";
    }
}
