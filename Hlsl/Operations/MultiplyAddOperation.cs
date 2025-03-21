namespace HLSLDecompiler.HLSL
{
    public class MultiplyAddOperation : Operation
    {
        public MultiplyAddOperation(HLSLTreeNode factor1, HLSLTreeNode factor2, HLSLTreeNode addend)
        {
            AddInput(factor1);
            AddInput(factor2);
            AddInput(addend);
        }

        public HLSLTreeNode Factor1 => Inputs[0];
        public HLSLTreeNode Factor2 => Inputs[1];
        public HLSLTreeNode Addend => Inputs[2];

        public override string Mnemonic => "madd";
    }
}
