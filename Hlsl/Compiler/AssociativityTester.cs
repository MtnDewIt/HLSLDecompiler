namespace HLSLDecompiler.HLSL
{
    public static class AssociativityTester
    {
        public static bool TestForMultiplication(HLSLTreeNode node)
        {
            switch (node)
            {
                case AddOperation _:
                case SubtractOperation _:
                    return false;
                default:
                    return true;
            }
        }
    }
}
