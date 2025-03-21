namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public class SubtractNegateTemplate : NodeTemplate<SubtractOperation>
    {
        public override bool Match(HLSLTreeNode node)
        {
            return node is SubtractOperation subtract && subtract.Subtrahend is NegateOperation;
        }

        public override HLSLTreeNode Reduce(SubtractOperation node)
        {
            return new AddOperation(node.Minuend, (node.Subtrahend as NegateOperation).Value);
        }
    }
}
