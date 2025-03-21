using System;
using System.Collections.Generic;

namespace HLSLDecompiler.HLSL
{
    public class HLSLTreeNode
    {
        public IList<HLSLTreeNode> Inputs { get; } = new List<HLSLTreeNode>();
        public IList<HLSLTreeNode> Outputs { get; } = new List<HLSLTreeNode>();

        public virtual HLSLTreeNode Reduce()
        {
            for (int i = 0; i < Inputs.Count; i++)
            {
                Inputs[i] = Inputs[i].Reduce();
            }
            return this;
        }

        public void Replace(HLSLTreeNode with)
        {
            foreach (var input in Inputs)
            {
                input.Outputs.Remove(this);
            }
            foreach (var output in Outputs)
            {
                for (int i = 0; i < output.Inputs.Count; i++)
                {
                    if (output.Inputs[i] == this)
                    {
                        output.Inputs[i] = with;
                    }
                }
                with.Outputs.Add(output);
            }
        }

        protected void AddInput(HLSLTreeNode node)
        {
            Inputs.Add(node);
            node.Outputs.Add(this);
            AssertLoopFree();
        }

        private void AssertLoopFree()
        {
            foreach (HLSLTreeNode output in Outputs)
            {
                AssertLoopFree(output);
                if (this == output)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        private void AssertLoopFree(HLSLTreeNode parent)
        {
            foreach (HLSLTreeNode upperParent in parent.Outputs)
            {
                if (this == upperParent)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
