namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public class NegateConstantTemplate : NodeTemplate<NegateOperation>
    {
        public override bool Match(HLSLTreeNode node)
        {
            return node is NegateOperation negate && ConstantMatcher.IsConstant(negate.Value);
        }

        public override HLSLTreeNode Reduce(NegateOperation node)
        {
            return new ConstantNode(-(node.Value as ConstantNode).Value);
        }
    }
}
