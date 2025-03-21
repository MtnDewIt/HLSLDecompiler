namespace HLSLDecompiler.HLSL
{
    public class NegateOperation : ConsumerOperation
    {
        public NegateOperation(HLSLTreeNode value)
        {
            AddInput(value);
        }

        public override string Mnemonic => "-";
    }
}
