namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public abstract class NodeTemplate<T> : INodeTemplate where T : HLSLTreeNode
    {
        public virtual bool Match(HLSLTreeNode node)
        {
            return node is T;
        }

        public abstract HLSLTreeNode Reduce(T node);

        public HLSLTreeNode Reduce(HLSLTreeNode node)
        {
            return Reduce(node as T);
        }
    }
}
