using HLSLDecompiler.DirectXShaderModel;
using System;
using System.Linq;
using System.Reflection.Metadata;

namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public static class ConstantMatcher
    {
        public static bool IsConstant(HLSLTreeNode node)
        {
            return node is ConstantNode;
        }

        public static bool IsZero(HLSLTreeNode node)
        {
            return node is ConstantNode constant && constant.Value == 0;
        }

        public static bool IsOne(HLSLTreeNode node)
        {
            return node is ConstantNode constant && constant.Value == 1;
        }

        public static bool IsNegativeOne(HLSLTreeNode node)
        {
            return node is ConstantNode constant && constant.Value == -1;
        }

        public static bool IsNegative(HLSLTreeNode node)
        {
            return node is ConstantNode constant && constant.Value < 0;
        }

        public static bool? TryEvaluateComparison(HLSLTreeNode node)
        {
            if (node is GroupNode group)
            {
                var firstValue = TryEvaluateComparison(group.Inputs.First());
                if (firstValue == null)
                {
                    return null;
                }
                if (group.Inputs.All(i => TryEvaluateComparison(i) == firstValue))
                {
                    return firstValue;
                }
            }
            else if (node is ComparisonNode comparison)
            {
                int? left = TryEvaluateValue(comparison.Left);
                if (left.HasValue)
                {
                    int? right = TryEvaluateValue(comparison.Right);
                    if (right.HasValue)
                    {
                        switch (comparison.Comparison)
                        {
                            case IfComparison.GT: return left > right;
                            case IfComparison.EQ: return left == right;
                            case IfComparison.GE: return left >= right;
                            case IfComparison.LT: return left < right;
                            case IfComparison.NE: return left != right;
                            case IfComparison.LE: return left <= right;
                        }
                    }
                }
            }
            return null;
        }

        public static int? TryEvaluateValue(HLSLTreeNode node)
        {
            if (IsOne(node))
            {
                return 1;
            }
            if (IsNegativeOne(node))
            {
                return -1;
            }
            else if (node is NegateOperation negate)
            {
                var negatedValue = TryEvaluateValue(negate.Value);
                if (negatedValue.HasValue)
                {
                    return -negatedValue.Value;
                }
            }
            return null;
        }
    }
}
