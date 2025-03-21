namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public class MultiplyNegativeOneTemplate : NodeTemplate<MultiplyOperation>
    {
        public override bool Match(HLSLTreeNode node)
        {
            return node is MultiplyOperation multiply &&
                (ConstantMatcher.IsNegativeOne(multiply.Factor1) || ConstantMatcher.IsNegativeOne(multiply.Factor2));
        }

        public override HLSLTreeNode Reduce(MultiplyOperation node)
        {
            return ConstantMatcher.IsNegativeOne(node.Factor1)
                ? new NegateOperation(node.Factor2)
                : new NegateOperation(node.Factor1);
        }
    }
}
