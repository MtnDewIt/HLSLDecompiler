namespace HLSLDecompiler.HLSL
{
    public class SineOperation : ConsumerOperation
    {
        public SineOperation(HLSLTreeNode value)
        {
            AddInput(value);
        }

        public override string Mnemonic => "sin";
    }
}
