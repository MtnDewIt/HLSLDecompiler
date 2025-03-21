using HLSLDecompiler.DirectXShaderModel;
using System;

namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public class CompareNegativeWithZeroTemplate : NodeTemplate<ComparisonNode>
    {
        public override bool Match(HLSLTreeNode node)
        {
            return node is ComparisonNode comp &&
                comp.Left is NegateOperation && ConstantMatcher.IsZero(comp.Right);
        }

        public override HLSLTreeNode Reduce(ComparisonNode node)
        {
            var comparison = node.Comparison switch
            {
                IfComparison.GT => IfComparison.LT,
                IfComparison.GE => IfComparison.LE,
                IfComparison.LT => IfComparison.GT,
                IfComparison.LE => IfComparison.GE,
                IfComparison.EQ => IfComparison.EQ,
                IfComparison.NE => IfComparison.NE,
                _ => throw new InvalidOperationException(node.Comparison.ToString()),
            };
            return new ComparisonNode((node.Left as NegateOperation).Value, node.Right, comparison);
        }
    }
}
