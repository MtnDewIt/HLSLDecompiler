namespace HLSLDecompiler.HLSL
{
    public class MoveOperation : ConsumerOperation
    {
        public MoveOperation(HLSLTreeNode value)
        {
            AddInput(value);
        }

        public override string Mnemonic => "mov";

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
