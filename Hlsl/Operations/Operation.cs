using System.Linq;

namespace HLSLDecompiler.HLSL
{
    public abstract class Operation : HLSLTreeNode
    {
        public abstract string Mnemonic { get; }

        public override string ToString()
        {
            string parameters = string.Join(", ", Inputs.Select(c => c.ToString()));
            return $"{Mnemonic}({parameters})";
        }
    }
}
