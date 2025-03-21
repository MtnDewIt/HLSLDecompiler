namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public class MoveTemplate : NodeTemplate<MoveOperation>
    {
        public override HLSLTreeNode Reduce(MoveOperation node)
        {
            return node.Value;
        }
    }
}
