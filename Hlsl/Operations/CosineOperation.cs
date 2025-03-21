namespace HLSLDecompiler.HLSL
{
    public class CosineOperation : ConsumerOperation
    {
        public CosineOperation(HLSLTreeNode value)
        {
            AddInput(value);
        }

        public override string Mnemonic => "cos";
    }
}
