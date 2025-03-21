﻿using HLSLDecompiler.Util;
using System.IO;
using System.Text;

namespace HLSLDecompiler
{
    enum ShaderFileFormat
    {
        Unknown,
        ShaderModel3,
        Dxbc,
        Rgxa
    }

    class FormatDetector
    {
        public static ShaderFileFormat Detect(Stream stream)
        {
            long tempPosition = stream.Position;
            var format = ShaderFileFormat.Unknown;

            using (var reader = new BinaryReader(stream, new UTF8Encoding(), true))
            {
                uint signature = (uint)reader.ReadInt32();
                if (signature == FourCC.Make("rgxa"))
                {
                    format = ShaderFileFormat.Rgxa;
                }
                else
                {
                    stream.Position = tempPosition;
                    signature = reader.ReadUInt32();
                    if (signature == 0xFFFE0300 || signature == 0xFFFF0300)
                    {
                        format = ShaderFileFormat.ShaderModel3;
                    }
                }
            }

            stream.Position = tempPosition;
            return format;
        }
    }
}
