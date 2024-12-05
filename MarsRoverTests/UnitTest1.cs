using FluentAssertions;
using MarsRover;
namespace MarsRoverTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        //ParsingPlateauTest
        [Test]
        public void TestParsingPlateauCorrectInput()
        {
            string input = "5 5";

            PlateauSize plateau = InputParser.ParsingPlateau(input);
            plateau.X.Should().Be(5);
            plateau.Y.Should().Be(5);
        }

        [Test]
        public void TestParsingPlateauIncorrectInput()
        {
            string input = "5 x ";

            Action act = () =>  InputParser.ParsingPlateau(input);

            act.Should().Throw<Exception>();
        }



        //ParsingPositionTest
        [Test]
        public void TestParsingPositionCorrectInput()
        {
            string input = "0 1 N";

            Position position = InputParser.ParsingPosition(input);
            position.X.Should().Be(0);
            position.Y.Should().Be(1);
            position.Facing.Should().Be(CompassDirection.N);
        }
        [Test]
        public void TestParsingPositionIncorrectInput()
        {
            string input = "5 N 2";

            Action act = () => InputParser.ParsingPlateau(input);

            act.Should().Throw<Exception>();
        }

        //ParsingInstructionTest
        [Test]
        public void TestParsigInstructionCorrectInput()
        {
            string input = "LMRMRMLM";


            List<Instruction> instructions = InputParser.ParsingInstructions(input);
            instructions.Should().BeEquivalentTo(new List<Instruction>
            {
                Instruction.L, Instruction.M, Instruction.R , Instruction.M, Instruction.R,Instruction.M, Instruction.L, Instruction.M
            });
        }
        [Test]
        public void TestParsingInstrcutionIncorrectInput()
        {
            string input = "LRMLAR4R";

            Action act = () => InputParser.ParsingPlateau(input);

            act.Should().Throw<Exception>();
        }


        //ParsingInputTest
        [Test]
        public void TestParsingCorrectInput()
        {
            string[] input = {
                "5 5",
                "1 2 N",
                "LMRMRMLM",
                "3 3 E",
                "LMRMRLRM"
            };

            var (plateau, roverPositionAndInstruction) = InputParser.ParsingInput(input);

            plateau.X.Should().Be(5);
            plateau.Y.Should().Be(5);
            roverPositionAndInstruction[0].Item1.X.Should().Be(1);
            roverPositionAndInstruction[0].Item1.Y.Should().Be(2);
            roverPositionAndInstruction[0].Item1.Facing.Should().Be(CompassDirection.N);
            roverPositionAndInstruction[0].Item2.Should().BeEquivalentTo(new List<Instruction>
            {
                Instruction.L, Instruction.M, Instruction.R , Instruction.M, Instruction.R,Instruction.M, Instruction.L, Instruction.M
            });

            roverPositionAndInstruction[1].Item1.X.Should().Be(3);
            roverPositionAndInstruction[1].Item1.Y.Should().Be(3);
            roverPositionAndInstruction[1].Item1.Facing.Should().Be(CompassDirection.E);
            roverPositionAndInstruction[1].Item2.Should().BeEquivalentTo(new List<Instruction>
            {
                Instruction.L, Instruction.M, Instruction.R , Instruction.M, Instruction.R,Instruction.L, Instruction.R, Instruction.M
            });
            roverPositionAndInstruction.Should().HaveCount(2);
        }
    }
}