using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2019
{
    public class Intcode
    {
        public long relativeBase = 0;
        private bool phaseSettingDone = true;
        public long input, output;
        public long phase = 0;
        private int id = 0;
        public long index;
        public string Program;
        List<long> Instructions = new List<long>();
        Dictionary<long, long> memory = new();
        public Intcode(string program)
        {
            Program = program;
            Instructions = Program.Split(',').Select(long.Parse).ToList();
            Reset();
        }
        public Intcode NeedPhaseSetting()
        {
            phaseSettingDone = false;
            return this;
        }
        public void SetId(int id)
        {
            this.id = id;
        }
        public void Reset()
        {
            memory.Clear();
            for (int i = 0; i < Instructions.Count; i++)
            {
                memory[i] = Instructions[i];
            }
            index = 0;
            relativeBase = 0;
        }
        public long Get(long position)
        {
            return getMemory(position);
        }
        public int ParameterMode(int mode)
        {
            long opcode = getMemory(index);
            int modulo = 10;
            for (int i = 0; i < mode; i++)
                modulo *= 10;
            return (int)((opcode / modulo) % 10);
        }
        public long Get(int parameter, long position)
        {
            if (parameter == 0) // position mode
                return getMemory(getMemory(position));
            if (parameter == 1)
                return getMemory(position);
            if (parameter == 2)
                return getMemory(getMemory(position) + relativeBase);
            throw new ArgumentException($"Parameter position {parameter} seems not correct");
        }

        private long Read()
        {
            //Console.WriteLine($"will give an input of {(phaseSettingDone ? input : phase)}");
            if (phaseSettingDone)
                return input;
            phaseSettingDone = true;
            return phase;
        }

        private void Output(long output)
        {
            this.output = output;
            //Console.WriteLine($"Just Got An Output {output}");
        }

        public void Set(int parameter, long position, long value)
        {
            //if (position >= Instructions.Count) { return; }
            if (parameter == 0) // position mode
            {
                memory[getMemory(position)] = value;
                return;
            }
            if (parameter == 1)
            {
                memory[position] = value;
                return;
            }
            if (parameter == 2)
            {
                memory[getMemory(position) + relativeBase] = value;
                return;
            }
            throw new ArgumentException("Parameter position seems not correct");
        }
        public void SetIndex(long value)
        {
            index = value;
        }
        public (bool done, long output) Run()
        {
            while (true)
            {
                switch (getMemory(index) % 100)
                {
                    case 99: return (true, output);
                    case 1: add(); index += 4; break;
                    case 2: multiply(); index += 4; break;
                    case 3: Input(); index += 2; break;
                    case 4: Output(); index += 2; return (false, output);
                    case 5: jumpIfTrue(); index += 3; break;
                    case 6: jumpIfFalse(); index += 3; break;
                    case 7: lessThan(); index += 4; break;
                    case 8: equals(); index += 4; break;
                    case 9: relativeOffset(); index += 2; break;
                }
            }
        }

        private void relativeOffset()
        {
            relativeBase += GetParameter(1);
        }

        private void equals()
        {
            if (GetParameter(1) == GetParameter(2))
                SetParameter(3, 1);
            else
                SetParameter(3, 0);
        }

        private void lessThan()
        {
            if (GetParameter(1) < GetParameter(2))
                SetParameter(3, 1);
            else
                SetParameter(3, 0);
        }

        private void jumpIfFalse()
        {
            if (GetParameter(1) == 0)
            {
                index = GetParameter(2) - 3; // car plus 3 en sortie
            }
        }

        private void jumpIfTrue()
        {
            if (GetParameter(1) != 0)
            {
                index = GetParameter(2) - 3; // car plus 3 en sortie
            }
        }
        public Func<int> FromInput;

        public void Input()
        {
            if (FromInput is not null)
                input = FromInput();
            if (phaseSettingDone)
                SetParameter(1, input);
            else
            {
                SetParameter(1, phase);
                phaseSettingDone = true;
            }
        }
        public void Output()
        {
            Output(GetParameter(1));
        }
        private void multiply()
        {
            SetParameter(3, GetParameter(1) * GetParameter(2));
        }
        private void add()
        {
            SetParameter(3, GetParameter(1) + GetParameter(2));
        }

        public void SetParameter(int parameterIndex, long value)
        {
            Set(ParameterMode(parameterIndex), index + parameterIndex, value);
        }
        public long GetParameter(int parameterIndex)
        {
            return Get(ParameterMode(parameterIndex), index + parameterIndex);
        }

        internal void SetInput(long v)
        {
            input = v;
        }
        private long getMemory(long index)
        {
            return memory.TryGetValue(index, out var res) ? res : 0;
        }
    }
}
