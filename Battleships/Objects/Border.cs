using System;
using System.Collections.Generic;
using Battleships.Interfaces;

namespace Battleships.Objects
{
    public class Border : IBorder
    {
        public int GameId { get; set; }
        public IList<int> StripP1 { get; set; }
        public IList<int> StripP2 { get; set; }
        public bool Next { get; set; }
        public DateTime Time { get; set; }
    }
}
