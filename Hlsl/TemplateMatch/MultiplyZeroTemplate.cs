namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public class MultiplyZeroTemplate : NodeTemplate<MultiplyOperation>
    {
        public override bool Match(HLSLTreeNode node)
        {
            return node is MultiplyOperation multiply &&
                (ConstantMatcher.IsZero(multiply.Factor1) || ConstantMatcher.IsZero(multiply.Factor2));
        }

        public override HLSLTreeNode Reduce(MultiplyOperation node)
        {
            return new ConstantNode(0);
        }
    }
}
