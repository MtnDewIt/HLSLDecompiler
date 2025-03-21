namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public class NegateNegateTemplate : NodeTemplate<NegateOperation>
    {
        public override bool Match(HLSLTreeNode node)
        {
            return node is NegateOperation negate && negate.Value is NegateOperation;
        }

        public override HLSLTreeNode Reduce(NegateOperation node)
        {
            return node.Value;
        }
    }
}
