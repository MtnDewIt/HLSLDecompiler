namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public interface INodeTemplate
    {
        bool Match(HLSLTreeNode node);
        HLSLTreeNode Reduce(HLSLTreeNode node);
    }
}
