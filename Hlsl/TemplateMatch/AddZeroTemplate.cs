﻿namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public class AddZeroTemplate : NodeTemplate<AddOperation>
    {
        public override bool Match(HLSLTreeNode node)
        {
            return node is AddOperation add &&
                (ConstantMatcher.IsZero(add.Addend1) || ConstantMatcher.IsZero(add.Addend2));
        }

        public override HLSLTreeNode Reduce(AddOperation node)
        {
            return ConstantMatcher.IsZero(node.Addend1)
                ? node.Addend2
                : node.Addend1;
        }
    }
}
