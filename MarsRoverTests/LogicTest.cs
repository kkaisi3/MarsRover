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
            Rover rover = new Rover(0, 0, CompassDirection.N);
            rover.RotateLeft();
            rover.Position.Facing.Should().Be(CompassDirection.W);


        }


        [Test]
        public void TestRotateRight()
        {
            Rover rover = new Rover(0, 0, CompassDirection.N);
            rover.RotateRight();
            rover.Position.Facing.Should().Be(CompassDirection.E);


        }
        [Test]
        public void TestRotateUsingBoth()
        {
            Rover rover = new Rover(0, 0, CompassDirection.N);
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
            Rover rover = new Rover(0, 0, CompassDirection.N);
            rover.Move();

            rover.Position.X.Should().Be(0);
            rover.Position.Y.Should().Be(1);


        }

        [Test]
        public void TestMoveFacingSouth()
        {
            Rover rover = new Rover(0, 0, CompassDirection.S);
            rover.Move();

            rover.Position.X.Should().Be(0);
            rover.Position.Y.Should().Be(-1);


        }

        [Test]
        public void TestMoveFacingWest()
        {
            Rover rover = new Rover(0, 0, CompassDirection.W);
            rover.Move();

            rover.Position.X.Should().Be(-1);
            rover.Position.Y.Should().Be(0);


        }

        [Test]
        public void TestMoveFacingEast()
        {
            Rover rover = new Rover(0, 0, CompassDirection.E);
            rover.Move();

            rover.Position.X.Should().Be(1);
            rover.Position.Y.Should().Be(0);


        }

        // Test Rotate Method
        [Test]

        public void TestWholeSequence()
        {
            var rover = new Rover(0, 0, CompassDirection.N);
            var instrcutions = new List<Instruction> { Instruction.M, Instruction.M, Instruction.R, Instruction.M, Instruction.L, Instruction.M };

            foreach (var instr in instrcutions)
            {
                rover.Instructions(instr);
            }

            rover.Position.Facing.Should().Be(CompassDirection.N);
            rover.Position.X.Should().Be(1);
            rover.Position.Y.Should().Be(3);
        }


    }
}
