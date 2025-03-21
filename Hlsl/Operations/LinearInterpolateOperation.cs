namespace HLSLDecompiler.HLSL
{
    public class LinearInterpolateOperation : Operation
    {
        public LinearInterpolateOperation(HLSLTreeNode amount, HLSLTreeNode value1, HLSLTreeNode value2)
        {
            AddInput(amount);
            AddInput(value1);
            AddInput(value2);
        }

        public HLSLTreeNode Amount => Inputs[0];
        public HLSLTreeNode Value1 => Inputs[1];
        public HLSLTreeNode Value2 => Inputs[2];

        public override string Mnemonic => "lrp";
    }
}
