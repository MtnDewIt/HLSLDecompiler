namespace HLSLDecompiler.HLSL
{
    public class ReciprocalSquareRootOperation : ConsumerOperation
    {
        public ReciprocalSquareRootOperation(HLSLTreeNode value)
        {
            AddInput(value);
        }

        public override string Mnemonic => "rsqrt";
    }
}
