namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public class AddSelfTemplate : NodeTemplate<AddOperation>
    {
        public override bool Match(HLSLTreeNode node)
        {
            return node is AddOperation add && add.Addend1 == add.Addend2;
        }

        public override HLSLTreeNode Reduce(AddOperation node)
        {
            return new MultiplyOperation(new ConstantNode(2), node.Addend1);
        }
    }
}
