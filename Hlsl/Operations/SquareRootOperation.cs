namespace HLSLDecompiler.HLSL
{
    public class SquareRootOperation : ConsumerOperation
    {
        public SquareRootOperation(HLSLTreeNode value)
        {
            AddInput(value);
        }

        public override string Mnemonic => "sqrt";
    }
}
