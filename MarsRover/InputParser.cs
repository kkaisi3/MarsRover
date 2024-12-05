using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class InputParser
    {
        public static PlateauSize ParsingPlateau(string input)
        {
            string[] parts = input.Split(' ');

            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);

            return new PlateauSize(x, y);
        }

        public static Position ParsingPosition(string input)
        {
            string[] parts = input.Split(" ");
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            CompassDirection facing = Enum.Parse<CompassDirection>(parts[2]);

            return new Position(x, y, facing);
        }

        public static List<Instruction> ParsingInstructions(string input)
        {
            var instructions = new List<Instruction>();

            foreach (char c in input)
            {
                Instruction instruction;
                switch (c)
                {
                    case 'L':
                        instruction = Instruction.L;
                        break;
                    case 'R':
                        instruction = Instruction.R;
                        break;
                    case 'M':
                        instruction = Instruction.M;
                        break;
                    default:
                        throw new Exception($"{c} is invalid");

                }
                instructions.Add(instruction);
            }
            return instructions;
        }

        public static (PlateauSize, List<(Position, List<Instruction>)>) ParsingInput(string[] input)
            {
                PlateauSize plateau = ParsingPlateau(input[0]);
                var roverPositionAndInstruction = new List<(Position, List<Instruction>)>();
                for(int i = 1; i<input.Length; i += 2)
                  {     
                    Position position = ParsingPosition(input[i]);
                    List<Instruction> instruction = ParsingInstructions(input[i + 1]);
                    roverPositionAndInstruction.Add((position, instruction));
                   }
                   return (plateau, roverPositionAndInstruction);
            }




    }

}
