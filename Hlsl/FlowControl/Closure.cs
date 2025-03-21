using HLSLDecompiler.DirectXShaderModel;
using System.Collections.Generic;

namespace HLSLDecompiler.HLSL.FlowControl
{
    public class Closure
    {
        public Dictionary<RegisterComponentKey, HLSLTreeNode> Outputs { get; }

        public Closure(Dictionary<RegisterComponentKey, HLSLTreeNode> outputs)
        {
            Outputs = outputs;
        }
    }
}
