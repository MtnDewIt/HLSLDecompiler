using HLSLDecompiler.DirectXShaderModel;

namespace HLSLDecompiler.HLSL
{
    public class RegisterInputNode : HLSLTreeNode, IHasComponentIndex
    {
        public RegisterInputNode(RegisterComponentKey registerComponentKey)
        {
            RegisterComponentKey = registerComponentKey;
        }

        public RegisterComponentKey RegisterComponentKey { get; }

        public int ComponentIndex => RegisterComponentKey.ComponentIndex;

        public override string ToString()
        {
            return RegisterComponentKey.ToString();
        }
    }
}
