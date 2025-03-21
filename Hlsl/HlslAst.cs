using HLSLDecompiler.HLSL.FlowControl;

namespace HLSLDecompiler.HLSL
{
    public class HLSLAst
    {
        public IStatement Statement { get; private set; }
        public RegisterState RegisterState { get; private set; }

        public HLSLAst(IStatement statement, RegisterState registerState)
        {
            Statement = statement;
            RegisterState = registerState;
        }
    }
}
