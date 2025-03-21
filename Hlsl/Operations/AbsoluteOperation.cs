namespace HLSLDecompiler.HLSL
{
    public class AbsoluteOperation : ConsumerOperation
    {
        public AbsoluteOperation(HLSLTreeNode value)
        {
            AddInput(value);
        }

        public override string Mnemonic => "abs";
    }
}
