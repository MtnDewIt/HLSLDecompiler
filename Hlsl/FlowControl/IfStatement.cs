namespace HLSLDecompiler.HLSL.FlowControl
{
    public class IfStatement : IStatement
    {
        public IfStatement(HLSLTreeNode comparison, Closure closure)
        {
            Comparison = comparison;
            Closure = closure;
            
            TrueBody = new StatementSequence(closure);
        }

        public Closure Closure { get; }
        public HLSLTreeNode Comparison { get; }
        
        public StatementSequence TrueBody { get; }
        public StatementSequence FalseBody { get; set; }
        public Closure TrueEndClosure { get; set; }
        public Closure FalseEndClosure { get; set; }
    }
}
