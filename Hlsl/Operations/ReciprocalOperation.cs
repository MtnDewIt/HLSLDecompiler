namespace HLSLDecompiler.HLSL
{
    public class ReciprocalOperation : ConsumerOperation
    {
        public ReciprocalOperation(HLSLTreeNode value)
        {
            AddInput(value);
        }

        public override string Mnemonic => "rcp";
    }
}
