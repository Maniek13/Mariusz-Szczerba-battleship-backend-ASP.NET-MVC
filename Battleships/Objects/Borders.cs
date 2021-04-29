using System;
using System.Collections.Generic;

namespace Battleships.Border
{
    public class Borders : IBorders
    {
        public int GameId { get; set; }
        public IList<int> StripP1 { get; set; }
        public IList<int> StripP2 { get; set; }
        public bool Next { get; set; }
        public DateTime Time { get; set; }
    }
}
