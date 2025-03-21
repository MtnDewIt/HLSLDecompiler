namespace HLSLDecompiler.HLSL
{
    public class MultiplyOperation : Operation
    {
        public MultiplyOperation(HLSLTreeNode factor1, HLSLTreeNode factor2)
        {
            AddInput(factor1);
            AddInput(factor2);
        }

        public HLSLTreeNode Factor1 => Inputs[0];
        public HLSLTreeNode Factor2 => Inputs[1];

        public override string Mnemonic => "mul";
    }
}
