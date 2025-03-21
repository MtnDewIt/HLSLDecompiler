namespace HLSLDecompiler.HLSL
{
    public class LogOperation : ConsumerOperation
    {
        public LogOperation(HLSLTreeNode value)
        {
            AddInput(value);
        }

        public override string Mnemonic => "log";
    }
}
