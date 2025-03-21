using System;
using System.Collections.Generic;
using System.Linq;

namespace HLSLDecompiler.HLSL
{
    public class TextureLoadOutputNode : HLSLTreeNode, IHasComponentIndex
    {
        private int _numTextureCoordinates;

        private TextureLoadOutputNode(RegisterInputNode sampler, HLSLTreeNode[] textureCoords, int componentIndex)
        {
            AddInput(sampler);
            foreach (HLSLTreeNode textureCoord in textureCoords)
            {
                AddInput(textureCoord);
            }
            _numTextureCoordinates = textureCoords.Length;
            ComponentIndex = componentIndex;
        }

        public static TextureLoadOutputNode Create(RegisterInputNode sampler, HLSLTreeNode[] textureCoords, int componentIndex)
        {
            return new TextureLoadOutputNode(sampler, textureCoords, componentIndex);
        }

        public static TextureLoadOutputNode CreateBias(RegisterInputNode sampler, HLSLTreeNode[] textureCoords, int componentIndex)
        {
            return new TextureLoadOutputNode(sampler, textureCoords, componentIndex)
            {
                Controls = TextureLoadControls.Bias
            };
        }

        public static TextureLoadOutputNode CreateLod(RegisterInputNode sampler, HLSLTreeNode[] textureCoords, int componentIndex)
        {
            return new TextureLoadOutputNode(sampler, textureCoords, componentIndex)
            {
                Controls = TextureLoadControls.Lod
            };
        }

        public static TextureLoadOutputNode CreateProj(RegisterInputNode sampler, HLSLTreeNode[] textureCoords, int componentIndex)
        {
            return new TextureLoadOutputNode(sampler, textureCoords, componentIndex)
            {
                Controls = TextureLoadControls.Project
            };
        }

        public static TextureLoadOutputNode CreateGrad(RegisterInputNode sampler, HLSLTreeNode[] textureCoords, int componentIndex,
            HLSLTreeNode[] derivativeX, HLSLTreeNode[] derivativeY)
        {
            var node = new TextureLoadOutputNode(sampler, textureCoords, componentIndex)
            {
                Controls = TextureLoadControls.Grad
            };
            foreach (HLSLTreeNode component in derivativeX)
            {
                node.AddInput(component);
            }
            foreach (HLSLTreeNode component in derivativeY)
            {
                node.AddInput(component);
            }
            return node;
        }

        public RegisterInputNode Sampler => (RegisterInputNode)Inputs[0];
        public IEnumerable<HLSLTreeNode> TextureCoordinateInputs => Inputs.Skip(1).Take(_numTextureCoordinates);
        public IEnumerable<HLSLTreeNode> DerivativeX => Inputs.Skip(1 + _numTextureCoordinates).Take(_numTextureCoordinates);
        public IEnumerable<HLSLTreeNode> DerivativeY => Inputs.Skip(1 + 2 * _numTextureCoordinates).Take(_numTextureCoordinates);
        public int ComponentIndex { get; }
        public TextureLoadControls Controls { get; private set; }
    }

    [Flags]
    public enum TextureLoadControls
    {
        None = 0,
        Bias = 1,
        Lod = 2,
        Grad = 4,
        Project = 8
    }
}
