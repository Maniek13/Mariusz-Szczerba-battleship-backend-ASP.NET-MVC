using Microsoft.AspNetCore.Mvc;
using Battleship.Core;

namespace Battleships.Controllers
{
    [Produces("application/json")]
    public class BattleshipController : Controller
    {
        public string Index()
        {
            return "Welcome to the battleship backend";
        }

        // GET: /Battleship/Ships/ 
        [HttpGet]
        public JsonResult Ships()
        {
            BattleshipCore core = new BattleshipCore();

            var data = core.UsersShips();

            Request.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Json(data);
        }

        // GET: /Battleship/moves?gameId=1&player=1
        [HttpGet]
        public JsonResult Moves(int gameId, int player, bool next)
        {
            BattleshipCore core = new BattleshipCore();

            var move = core.ComputerMove(gameId, player, next);

            Request.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Json(move);
        }
    }
}
