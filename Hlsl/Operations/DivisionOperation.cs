namespace HLSLDecompiler.HLSL
{
    public class DivisionOperation : Operation
    {
        public DivisionOperation(HLSLTreeNode dividend, HLSLTreeNode divisor)
        {
            AddInput(dividend);
            AddInput(divisor);
        }

        public HLSLTreeNode Dividend => Inputs[0];
        public HLSLTreeNode Divisor => Inputs[1];

        public override string Mnemonic => "div";
    }
}
