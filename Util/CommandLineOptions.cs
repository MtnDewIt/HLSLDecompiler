using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLSLDecompiler.Util
{
    public class CommandLineOptions
    {
        public string InputFilename { get; }
        public bool DoAstAnalysis { get; }

        public static CommandLineOptions Parse(string args)
        {
            return new CommandLineOptions(args);
        }

        private CommandLineOptions(string args)
        {
            var results = new List<string>();
            var currentArg = new StringBuilder();
            var partStart = -1;
            var quoted = false;

            for (var i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case ' ' when !quoted:
                    case '>' when !quoted:
                    case '\t' when !quoted:
                        if (partStart != -1)
                            currentArg.Append(args.AsSpan(partStart, i - partStart));
                        if (currentArg.Length > 0)
                        {
                            var arg = currentArg.ToString();
                            results.Add(arg);
                        }
                        currentArg.Clear();
                        partStart = -1;
                        break;
                    case '"':
                        quoted = !quoted;
                        if (partStart != -1)
                            currentArg.Append(args.AsSpan(partStart, i - partStart));
                        partStart = -1;
                        break;
                    default:
                        if (partStart == -1)
                            partStart = i;
                        break;
                }
            }

            if (partStart != -1)
                currentArg.Append(args.AsSpan(partStart));

            if (currentArg.Length > 0)
            {
                var arg = currentArg.ToString();
                results.Add(arg);
            }

            foreach (string arg in results)
            {
                if (arg.StartsWith("--"))
                {
                    string option = arg.Substring(2);
                    if (option == "ast")
                    {
                        DoAstAnalysis = true;
                    }
                    else
                    {
                        Console.WriteLine("Unknown option: --" + option);
                    }
                }
                else
                {
                    InputFilename = arg;
                }
            }
        }
    }
}
