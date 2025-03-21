namespace HLSLDecompiler.HLSL.FlowControl
{
    public class BreakStatement : IStatement
    {
        public BreakStatement(HLSLTreeNode comparison, Closure closure)
        {
            Comparison = comparison;
            Closure = closure;
        }

        public HLSLTreeNode Comparison { get; }
        public Closure Closure { get; }
    }
}
