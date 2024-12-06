using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;

namespace MarsRover
{
    public class Rover
    {
       public Position Position { get; set; }
        public PlateauSize PlateauSize { get; set; }

        public Rover(int x, int y, CompassDirection facing, PlateauSize plateauSize)
        {
            Position = new Position(x, y, facing);
            PlateauSize = plateauSize;
        }
        private static readonly Dictionary<CompassDirection, CompassDirection> LeftRotationLogic = new Dictionary<CompassDirection, CompassDirection>
        {
            {CompassDirection.N, CompassDirection.W},
            {CompassDirection.W,CompassDirection.S},
            {CompassDirection.S,CompassDirection.E},
            {CompassDirection.E,CompassDirection.N}
        };
        private static readonly Dictionary<CompassDirection, CompassDirection> RightRotationLogic = new Dictionary<CompassDirection, CompassDirection>
        {
            {CompassDirection.N, CompassDirection.E},
            {CompassDirection.W,CompassDirection.N},
            {CompassDirection.S,CompassDirection.W},
            {CompassDirection.E,CompassDirection.S}
        };



        public void RotateLeft()
        {
            Position.Facing = LeftRotationLogic[Position.Facing];
        }

        public void RotateRight()
        {
           Position.Facing = RightRotationLogic[Position.Facing];
        }
        
        public void Move()
        {
            switch (Position.Facing)
            {
                case CompassDirection.N:
                   if(Position.Y < PlateauSize.Y)
                    Position.Y += 1;
                        break;
                case CompassDirection.W:
                    if (Position.X > 0)
                        Position.X -= 1 ;
                    break;
                case CompassDirection.S:
                    if (Position.Y > 0)
                        Position.Y -= 1;
                    break;
                case CompassDirection.E:
                    if (Position.X < PlateauSize.X)
                        Position.X += 1 ;
                    break;
            }
        }
        
        
        public void Instructions(Instruction instruction)
        {
            switch (instruction) 
            {
                case Instruction.M:
                    Move();
                    break;
                case Instruction.L:
                    RotateLeft();
                    break;
                case Instruction.R:
                    RotateRight();
                    break;
                

            }
        }
    }
}
