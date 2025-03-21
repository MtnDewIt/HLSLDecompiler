using System;
using System.Collections.Generic;
using System.Text;

namespace HLSLDecompiler.Util
{
    public class CommandLineOptions
    {
        public string InputFilename { get; }
        public bool DoAstAnalysis { get; }
        public bool Compile { get; }
        public string Version { get; }
        public string EntryPoint { get; }

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

            // TODO: Redo Input Parsing

            var argument = results[0];

            if (argument.StartsWith("--"))
            {
                string option = argument.Substring(2);
                if (option == "ast")
                {
                    DoAstAnalysis = true;

                    InputFilename = results[1];
                }
                else if (option == "compile")
                {
                    Compile = true;

                    InputFilename = results[1];

                    EntryPoint = results[2];

                    if (results[3] == "ps_3_0" || results[3] == "vs_3_0")
                    {
                        Version = results[3];
                    }
                    else
                    {
                        Console.WriteLine("Unknown Version: " + results[3]);
                    }
                }
                else
                {
                    Console.WriteLine("Unknown option: --" + option);
                }
            }
            else
            {
                InputFilename = results[0];
            }
        }
    }
}
