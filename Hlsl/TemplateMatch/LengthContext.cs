﻿namespace HLSLDecompiler.HLSL.TemplateMatch
{
    public class LengthContext : IGroupContext
    {
        public LengthContext(GroupNode value)
        {
            Value = value;
        }

        public GroupNode Value { get; private set; }
    }
}
