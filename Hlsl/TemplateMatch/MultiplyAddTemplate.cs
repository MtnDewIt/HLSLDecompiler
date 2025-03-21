namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public class MultiplyAddTemplate : NodeTemplate<MultiplyAddOperation>
    {
        public override HLSLTreeNode Reduce(MultiplyAddOperation node)
        {
            var multiplication = new MultiplyOperation(node.Factor1, node.Factor2);
            return new AddOperation(multiplication, node.Addend);
        }
    }
}
