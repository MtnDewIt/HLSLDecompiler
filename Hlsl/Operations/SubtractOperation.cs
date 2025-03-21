namespace HLSLDecompiler.HLSL
{
    public class SubtractOperation : Operation
    {
        public SubtractOperation(HLSLTreeNode minuend, HLSLTreeNode subtrahend)
        {
            AddInput(minuend);
            AddInput(subtrahend);
        }

        public HLSLTreeNode Minuend => Inputs[0];
        public HLSLTreeNode Subtrahend => Inputs[1];

        public override string Mnemonic => "sub";
    }
}
