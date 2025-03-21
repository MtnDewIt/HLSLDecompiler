namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public class SubtractZeroTemplate : NodeTemplate<SubtractOperation>
    {
        public override bool Match(HLSLTreeNode node)
        {
            return node is SubtractOperation subtract &&
                ((ConstantMatcher.IsZero(subtract.Minuend) && !ConstantMatcher.IsZero(subtract.Subtrahend))
                || (!ConstantMatcher.IsZero(subtract.Minuend) && ConstantMatcher.IsZero(subtract.Subtrahend)));
        }

        public override HLSLTreeNode Reduce(SubtractOperation node)
        {
            if (ConstantMatcher.IsZero(node.Minuend))
            {
                return new NegateOperation(node.Subtrahend);
            }
            return node.Minuend;
        }
    }
}
