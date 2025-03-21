namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public class ReciprocalSquareRootTemplate : NodeTemplate<ReciprocalSquareRootOperation>
    {
        public override HLSLTreeNode Reduce(ReciprocalSquareRootOperation node)
        {
            return new DivisionOperation(new ConstantNode(1), new SquareRootOperation(node.Value));
        }
    }
}
