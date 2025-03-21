using System;
using System.IO;

namespace HLSLDecompiler.D3D
{
    public class D3DIncludeManager(string root_directory = "") : D3DInclude(root_directory)
    {
        public string ReadResource(string filepath, string _parent_directory = null)
        {
            string parent_directory = _parent_directory ?? DirectoryMap[IntPtr.Zero];

            string relative_path = Path.Combine(parent_directory, filepath);

            FileInfo file = new FileInfo(relative_path);

            if (!file.Exists)
                throw new Exception($"Couldn't find file {relative_path}");

            using (Stream stream = file.OpenRead())
            {
                if (stream == null)
                {
                    throw new Exception($"Couldn't find file {relative_path}");
                }
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        protected override int Open(D3D.INCLUDE_TYPE includeType, string filepath, string directory, ref string hlsl_source)
        {
            switch (includeType)
            {
                case D3D.INCLUDE_TYPE.D3D_INCLUDE_LOCAL:
                    hlsl_source = ReadResource(filepath, directory);
                    return 0;
                case D3D.INCLUDE_TYPE.D3D_INCLUDE_SYSTEM:
                    hlsl_source = ReadResource(filepath, base.DirectoryMap[IntPtr.Zero]);
                    return 0;
                default:
                    throw new Exception("Unimplemented include type");
            }
        }
    }
}
