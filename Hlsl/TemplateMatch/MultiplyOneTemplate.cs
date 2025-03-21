namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public class MultiplyOneTemplate : NodeTemplate<MultiplyOperation>
    {
        public override bool Match(HLSLTreeNode node)
        {
            return node is MultiplyOperation multiply &&
                (ConstantMatcher.IsOne(multiply.Factor1) || ConstantMatcher.IsOne(multiply.Factor2));
        }

        public override HLSLTreeNode Reduce(MultiplyOperation node)
        {
            return ConstantMatcher.IsOne(node.Factor1)
                ? node.Factor2
                : node.Factor1;
        }
    }
}
