namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public interface IGroupTemplate
    {
        IGroupContext Match(HLSLTreeNode node);
        HLSLTreeNode Reduce(HLSLTreeNode node, IGroupContext groupContext);
    }
}
