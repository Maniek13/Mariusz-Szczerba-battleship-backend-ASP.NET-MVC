using System;
using System.Collections.Generic;

namespace Battleships.Border
{
    interface iBorders
    {
        int GameId { get; set; }
        IList<int> StripP1 { get; set; }
        IList<int> StripP2 { get; set; }
        bool Next { get; set; }
        DateTime Time { get; set; }
    }
}
