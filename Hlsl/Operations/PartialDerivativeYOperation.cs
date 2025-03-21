namespace HLSLDecompiler.HLSL
{
    public class PartialDerivativeYOperation : ConsumerOperation
    {
        public PartialDerivativeYOperation(HLSLTreeNode value)
        {
            AddInput(value);
        }

        public override string Mnemonic => "ddy";
    }
}
