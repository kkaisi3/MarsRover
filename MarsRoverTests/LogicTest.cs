using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MarsRover;

namespace MarsRoverTests
{
    internal class LogicTest
    {

        // Testing rotate
        [Test]
        public void TestRotateLeft()
        {
            Rover rover = new Rover(0, 0, CompassDirection.N, new PlateauSize(5,5));
            rover.RotateLeft();
            rover.Position.Facing.Should().Be(CompassDirection.W);


        }


        [Test]
        public void TestRotateRight()
        {
            Rover rover = new Rover(0, 0, CompassDirection.N, new PlateauSize(5, 5));
            rover.RotateRight();
            rover.Position.Facing.Should().Be(CompassDirection.E);


        }
        [Test]
        public void TestRotateUsingBoth()
        {
            Rover rover = new Rover(0, 0, CompassDirection.N , new PlateauSize(5, 5));
            rover.RotateLeft();
            rover.RotateLeft();
            rover.RotateRight();
            rover.RotateRight();
            rover.Position.Facing.Should().Be(CompassDirection.N);


        }
        //Test moving
        [Test]
        public void TestMoveFacingNorth()
        {
            Rover rover = new Rover(0, 0, CompassDirection.N , new PlateauSize(5, 5));
            rover.Move();

            rover.Position.X.Should().Be(0);
            rover.Position.Y.Should().Be(1);


        }

        [Test]
        public void TestMoveFacingSouth()
        {
            Rover rover = new Rover(0, 1, CompassDirection.S , new PlateauSize(5, 5));
            rover.Move();

            rover.Position.X.Should().Be(0);
            rover.Position.Y.Should().Be(0);


        }

        [Test]
        public void TestMoveFacingWest()
        {
            Rover rover = new Rover(1, 0, CompassDirection.W, new PlateauSize(5, 5));
            rover.Move();

            rover.Position.X.Should().Be(0);
            rover.Position.Y.Should().Be(0);


        }

        [Test]
        public void TestMoveFacingEast()
        {
            Rover rover = new Rover(0, 0, CompassDirection.E , new PlateauSize(5, 5));
            rover.Move();

            rover.Position.X.Should().Be(1);
            rover.Position.Y.Should().Be(0);
        }

        //Test Plateau
        [Test]
        public void TestMovePastThePlateau()
        {
            Rover rover = new Rover(5, 5, CompassDirection.N, new PlateauSize(5, 5));
            rover.Move();

            rover.Position.X.Should().Be(5);
            rover.Position.Y.Should().Be(5);
        }
        [Test]
        public void TestinvalidPlateau()
        {
            Action action = () => new Rover(5, 5, CompassDirection.N, null);
           

            action.Should().Throw<ArgumentException>();
        }


        // Test Instruction
        [Test]

        public void TestWholeSequence()
        {
            var rover = new Rover(0, 0, CompassDirection.N, new PlateauSize(5, 5));
            var instrcutions = new List<Instruction> { Instruction.M, Instruction.M, Instruction.R, Instruction.M, Instruction.L, Instruction.M };

            foreach (var instr in instrcutions)
            {
                rover.Instructions(instr);
            }

            rover.Position.Facing.Should().Be(CompassDirection.N);
            rover.Position.X.Should().Be(1);
            rover.Position.Y.Should().Be(3);
        }

        public void TestEmptyInstruction()
        {
            var rover = new Rover(0, 0, CompassDirection.N, new PlateauSize(5, 5));
            var instrcutions = new List<Instruction>();

            foreach (var instr in instrcutions)
            {
                rover.Instructions(instr);
            }

            rover.Position.Facing.Should().Be(CompassDirection.N);
            rover.Position.X.Should().Be(0);
            rover.Position.Y.Should().Be(0);
        }




    }
}
