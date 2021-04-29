using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Move
{
    public class Move : IMove
    {
        public int Message { get; set; }
        public int Hit { get; set; }
        public int Field { get; set; }
    }
}
