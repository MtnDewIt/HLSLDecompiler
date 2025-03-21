namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public class AddNegateTemplate : NodeTemplate<AddOperation>
    {
        public override bool Match(HLSLTreeNode node)
        {
            return node is AddOperation add &&
                ((add.Addend1 is NegateOperation && add.Addend2 is NegateOperation == false)
                || (add.Addend1 is NegateOperation == false && add.Addend2 is NegateOperation));
        }

        public override HLSLTreeNode Reduce(AddOperation node)
        {
            if (node.Addend1 is NegateOperation negate)
            {
                return new SubtractOperation(node.Addend2, negate.Value);
            }
            return new SubtractOperation(node.Addend1, (node.Addend2 as NegateOperation).Value);
        }
    }
}
