namespace HLSLDecompiler.HLSL
{
    public class CompareOperation : Operation
    {
        public CompareOperation(HLSLTreeNode value, HLSLTreeNode lessValue, HLSLTreeNode greaterEqualValue)
        {
            AddInput(value);
            AddInput(lessValue);
            AddInput(greaterEqualValue);
        }

        public HLSLTreeNode Value => Inputs[0];
        public HLSLTreeNode LessValue => Inputs[1];
        public HLSLTreeNode GreaterEqualValue => Inputs[2];

        public override string Mnemonic => "cmp";
    }
}
