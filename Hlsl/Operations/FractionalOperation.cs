namespace HLSLDecompiler.HLSL
{
    public class FractionalOperation : ConsumerOperation
    {
        public FractionalOperation(HLSLTreeNode value)
        {
            AddInput(value);
        }

        public override string Mnemonic => "frc";
    }
}
