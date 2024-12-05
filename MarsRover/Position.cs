using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Position
    {
        public int X {  get; set; }
        public int Y { get; set; }
        public CompassDirection Facing { get; set; }

        public Position(int x, int y, CompassDirection facing)
        {
            X = x;
            Y = y;
            Facing = facing;

        }
    }
}
