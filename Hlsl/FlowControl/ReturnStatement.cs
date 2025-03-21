namespace HLSLDecompiler.HLSL.FlowControl
{
    public class ReturnStatement : IStatement
    {
        public ReturnStatement(Closure closure)
        {
            Closure = closure;
        }

        public Closure Closure { get; }
    }
}
