﻿using System.Collections.Generic;

namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public class TemplateMatcher
    {
        private List<INodeTemplate> _templates;
        private List<IGroupTemplate> _groupTemplates;
        private NodeGrouper _nodeGrouper;

        public TemplateMatcher(NodeGrouper nodeGrouper)
        {
            _templates = new List<INodeTemplate>
            {
                new AddConstantsTemplate(),
                new AddNegateTemplate(),
                new AddNegativeTemplate(),
                new AddSelfTemplate(),
                new AddZeroTemplate(),
                new MoveTemplate(),
                new MultiplyAddTemplate(),
                new MultiplyConstantsTemplate(),
                new MultiplyConstantTemplate(),
                new MultiplyNegativeOneTemplate(),
                new MultiplyOneTemplate(),
                new MultiplyReciprocalDivisionTemplate(),
                new MultiplyZeroTemplate(),
                new NegateConstantTemplate(),
                new NegateNegateTemplate(),
                new ReciprocalReciprocalSquareRootTemplate(),
                new ReciprocalSquareRootTemplate(),
                new SubtractNegateTemplate(),
                new SubtractZeroTemplate(),
                new CompareNegativeWithZeroTemplate()
            };
            _groupTemplates = new List<IGroupTemplate>
            {
                new DotProduct2Template(this),
                new DotProduct3Template(this),
                new DotProduct4Template(this),
                new LengthTemplate()
            };
            _nodeGrouper = nodeGrouper;
        }

        public HLSLTreeNode Reduce(HLSLTreeNode node)
        {
            return ReduceDepthFirst(node);
        }

        public bool CanGroupComponents(HLSLTreeNode a, HLSLTreeNode b, bool allowMatrixColumn)
        {
            return _nodeGrouper.CanGroupComponents(a, b, allowMatrixColumn);
        }

        public bool SharesMatrixColumnOrRow(HLSLTreeNode x, HLSLTreeNode y)
        {
            if (x is RegisterInputNode r1 && y is RegisterInputNode r2)
            {
                return _nodeGrouper.SharesMatrixColumnOrRow(r1, r2);
            }
            return false;
        }

        private HLSLTreeNode ReduceDepthFirst(HLSLTreeNode node)
        {
            if (ConstantMatcher.IsConstant(node) || IsRegister(node))
            {
                return node;
            }
            for (int i = 0; i < node.Inputs.Count; i++)
            {
                HLSLTreeNode input = node.Inputs[i];
                node.Inputs[i] = ReduceDepthFirst(input);
            }
            foreach (INodeTemplate template in _templates)
            {
                if (template.Match(node))
                {
                    var replacement = template.Reduce(node);
                    Replace(node, replacement);
                    return ReduceDepthFirst(replacement);
                }
            }
            foreach (IGroupTemplate template in _groupTemplates)
            {
                IGroupContext groupContext = template.Match(node);
                if (groupContext != null)
                {
                    var replacement = template.Reduce(node, groupContext);
                    Replace(node, replacement);
                    return ReduceDepthFirst(replacement);
                }
            }
            return node;
        }

        private static void Replace(HLSLTreeNode node, HLSLTreeNode with)
        {
            if (node == with)
            {
                return;
            }
            foreach (var input in node.Inputs)
            {
                input.Outputs.Remove(node);
            }
            foreach (var output in node.Outputs)
            {
                for (int i = 0; i < output.Inputs.Count; i++)
                {
                    if (output.Inputs[i] == node)
                    {
                        output.Inputs[i] = with;
                    }
                }
                with.Outputs.Add(output);
            }
        }

        private static bool IsRegister(HLSLTreeNode node)
        {
            return node is RegisterInputNode;
        }
    }
}
