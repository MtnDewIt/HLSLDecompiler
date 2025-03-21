namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public class MultiplyReciprocalDivisionTemplate : NodeTemplate<MultiplyOperation>
    {
        public override bool Match(HLSLTreeNode node)
        {
            return node is MultiplyOperation multiply
                && multiply.Factor1 is DivisionOperation division
                && ConstantMatcher.IsOne(division.Dividend);
        }

        public override HLSLTreeNode Reduce(MultiplyOperation node)
        {
            return new DivisionOperation(node.Factor2, (node.Factor1 as DivisionOperation).Divisor);
        }
    }
}
