namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public class AddConstantsTemplate : NodeTemplate<AddOperation>
    {
        public override bool Match(HLSLTreeNode node)
        {
            return node is AddOperation add
                && ConstantMatcher.IsConstant(add.Addend1)
                && ConstantMatcher.IsConstant(add.Addend2);
        }

        public override HLSLTreeNode Reduce(AddOperation node)
        {
            var value = (node.Addend1 as ConstantNode).Value + (node.Addend2 as ConstantNode).Value;
            return new ConstantNode(value);
        }
    }
}
