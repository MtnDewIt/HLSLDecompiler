namespace HLSLDecompiler.HLSL
{
    public abstract class ConsumerOperation : Operation
    {
        public HLSLTreeNode Value => Inputs[0];
    }
}
