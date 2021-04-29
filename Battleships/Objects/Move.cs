using Battleships.Interfaces;

namespace Battleships.Objects
{
    public class Move : IMove
    {
        public int Message { get; set; }
        public int Hit { get; set; }
        public int Field { get; set; }
    }
}
