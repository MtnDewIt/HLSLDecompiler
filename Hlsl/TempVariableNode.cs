using HLSLDecompiler.DirectXShaderModel;

namespace HLSLDecompiler.HLSL
{
    public class TempVariableNode : HLSLTreeNode, IHasComponentIndex
    {
        public TempVariableNode(RegisterComponentKey registerComponentKey)
        {
            RegisterComponentKey = registerComponentKey;
        }

        public RegisterComponentKey RegisterComponentKey { get; }

        public int ComponentIndex => RegisterComponentKey.ComponentIndex;

        public int? DeclarationIndex { get; set; }

        public override string ToString()
        {
            string index = DeclarationIndex?.ToString() ?? string.Empty;
            return $"t{index}.{"xyzw"[ComponentIndex]}";
        }
    }
}
