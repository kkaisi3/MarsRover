using System.Linq.Expressions;

namespace MarsRover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
                };
            try
            {
                var (plateau, roverPositionAndInstruction) = InputParser.ParsingInput(input);
                Console.WriteLine($"Size of plateau is {plateau.X} x {plateau.Y}");

                for (int i = 0; i < roverPositionAndInstruction.Count; i++)
                {
                    var (position, instruction) = roverPositionAndInstruction[i];
                    Console.WriteLine($"Rover {i + 1} Starting : {position.X}, {position.Y}, {position.Facing}");
                    Console.WriteLine($"Rover {i + 1} Instructions: {string.Join("", instruction)}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }


    }
       

        
}
