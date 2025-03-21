namespace HLSLDecompiler.HLSL.FlowControl
{
    public class ClipStatement : IStatement
    {
        public HLSLTreeNode Value { get; }

        public ClipStatement(HLSLTreeNode value, Closure closure)
        {
            Value = value;
            Closure = closure;
        }

        public Closure Closure { get; }
    }
}
