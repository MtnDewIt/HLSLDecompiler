using System;

namespace HLSLDecompiler.DirectXShaderModel
{
    [Flags]
    public enum D3D10OperandModifier
    {
        None = 0,
        Neg = 1,
        Abs = 2
    }
}
