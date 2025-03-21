﻿using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HLSLDecompiler.DirectXShaderModel
{
    public class ShaderReader : BinaryReader
    {
        public ShaderReader(Stream input, bool leaveOpen = false)
            : base(input, new UTF8Encoding(false, true), leaveOpen)
        {
        }

        virtual public ShaderModel ReadShader()
        {
            // Version token
            byte minorVersion = ReadByte();
            byte majorVersion = ReadByte();
            ShaderType shaderType = (ShaderType)ReadUInt16();

            var instructions = new List<Instruction>();
            while (true)
            {
                D3D9Instruction instruction = ReadInstruction();
                instructions.Add(instruction);
                if (instruction.Opcode == Opcode.End) break;
            }

            return new ShaderModel(majorVersion, minorVersion, shaderType, instructions);
        }

        private D3D9Instruction ReadInstruction()
        {
            uint instructionToken = ReadUInt32();
            Opcode opcode = (Opcode)(instructionToken & 0xffff);

            int size;
            if (opcode == Opcode.Comment)
            {
                size = (int)((instructionToken >> 16) & 0x7FFF);
            }
            else
            {
                size = (int)((instructionToken >> 24) & 0x0f);
            }

            uint[] paramTokens = new uint[size];
            for (int i = 0; i < size; i++)
            {
                paramTokens[i] = ReadUInt32();
            }
            var instruction = new D3D9Instruction(instructionToken, paramTokens);
            InstructionVerifier.Verify(instruction);
            return instruction;
        }
    }
}
