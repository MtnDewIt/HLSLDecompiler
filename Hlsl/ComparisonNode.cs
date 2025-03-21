using HLSLDecompiler.DirectXShaderModel;
using System;

namespace HLSLDecompiler.HLSL
{
    public class ComparisonNode : HLSLTreeNode
    {
        public ComparisonNode(HLSLTreeNode left, HLSLTreeNode right, IfComparison comparison)
        {
            AddInput(left);
            AddInput(right);
            Comparison = comparison;
        }

        public HLSLTreeNode Left => Inputs[0];
        public HLSLTreeNode Right => Inputs[1];
        public IfComparison Comparison { get; }

        public override string ToString()
        {
            string comparison;
            switch (Comparison)
            {
                case IfComparison.GT: comparison = ">"; break;
                case IfComparison.EQ: comparison = "=="; break;
                case IfComparison.GE: comparison = ">="; break;
                case IfComparison.LT: comparison = "<"; break;
                case IfComparison.NE: comparison = "!="; break;
                case IfComparison.LE: comparison = "<="; break;
                default: throw new NotImplementedException(Comparison.ToString());
            }
            return $"{Left} {comparison} {Right}";
        }
    }
}
