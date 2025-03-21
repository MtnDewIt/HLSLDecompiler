namespace HLSLDecompiler.HLSL
{
    public class AddOperation : Operation
    {
        public AddOperation(HLSLTreeNode addend1, HLSLTreeNode addend2)
        {
            AddInput(addend1);
            AddInput(addend2);
        }

        public HLSLTreeNode Addend1 => Inputs[0];
        public HLSLTreeNode Addend2 => Inputs[1];

        public override string Mnemonic => "add";
    }
}
