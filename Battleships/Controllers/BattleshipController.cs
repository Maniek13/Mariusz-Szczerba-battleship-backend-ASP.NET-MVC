using Microsoft.AspNetCore.Mvc;
using Battleship.Core;

namespace Battleships.Controllers
{
    [Produces("application/json")]
    public class BattleshipController : Controller
    {
        BattleshipCore core = new BattleshipCore();
        public string Index()
        {
            return "Welcome to the battleship backend";
        }

        // GET: /Battleship/Ships/ 
        [HttpGet]
        public JsonResult Ships()
        {
            var data = core.UsersShips();
            return Json(data);
        }

        // GET: /Battleship/moves?gameId=1&player=1
        [HttpGet]
        public JsonResult Moves(int gameId, int player, bool next)
        {
            var move = core.ComputerMove(gameId, player, next);
            return Json(move);
        }
    }
}
