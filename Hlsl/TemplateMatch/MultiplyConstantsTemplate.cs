namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public class MultiplyConstantsTemplate : NodeTemplate<MultiplyOperation>
    {
        public override bool Match(HLSLTreeNode node)
        {
            return node is MultiplyOperation multiply
                && ConstantMatcher.IsConstant(multiply.Factor1)
                && ConstantMatcher.IsConstant(multiply.Factor2);
        }

        public override HLSLTreeNode Reduce(MultiplyOperation node)
        {
            var value = (node.Factor1 as ConstantNode).Value * (node.Factor2 as ConstantNode).Value;
            return new ConstantNode(value);
        }
    }
}
