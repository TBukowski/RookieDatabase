using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RookieDatabase.Data;
using RookieDatabase.Helpers;
using RookieDatabase.Models;
using RookieDatabase.ViewModels;
using static RookieDatabase.Enums.Enums;

namespace RookieDatabase.Controllers
{
    public class HomeController : Controller
    {
        private readonly RookieContext _context;

        public HomeController(RookieContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var rookie = new RookieViewModel
            {                
                Positions = Enum.GetValues(typeof(PositionValue)).Cast<PositionValue>()
            };
            
            return View(rookie);
        }

        //CREATE A POSITION TABLE VIEW - POSITION TITLE, TABLE W/ PLAYERS, 
        //PLAYER NAMES LINK TO PLAYER EDIT VIEW, PLAYER SEARCH

        //[Route("Home/Position")] --Do not need if action is named correctly
        public IActionResult Position(string position)
        {
            //the logic in this action doesn't make sense....
            //this is supposed to be an action that represents a sub-group of players that play a certain position.
            //you need to update the database call below to filter by the position being passed in...you don't want a qb showing up under RB
            //just for future reference...it's not good to tolist and then select. you can get it from the context and select before tolisting.
            //doing it the way that you did causes the code to have to loop through all of the players twice.
            //it's better to do this => _context.Player.Select(r => whatever).tolist();
            //another tip for readability...try to keep related blocks of code together instead of separated.
            //you have var vm = new PositionViewModel();, but do not use it until way at the bottom
            //where you have vm.Rookies = you could declare and set the property in one statement using var vm = new PositionViewModel { Rookies = rookies };

            //SELECT ALL ROOKIES WHERE POSITION EQUAL THE PARAMETER POSITION
            //var rookies = rookieList.Select(r => new PositionDTO

            var rookieList = _context.Players.Select(r => r.Position == position).ToList();
            {
                PlayerName = r.PlayerName,
                Position = r.Position,
                Age = r.Age,
                Height = r.Height,
                Weight = r.Weight,
                Development = r.Development,
                OVR = r.OVR,
                SPD = r.SPD,
                ACC = r.ACC,
                STR = r.STR,
                AGI = r.AGI,
                ELU = r.ELU,
                BCV = r.BCV,
                CAR = r.CAR,
                JKM = r.JKM,
                SPM = r.SPM,
                SFA = r.SFA,
                TRK = r.TRK,
                CTH = r.CTH,
                CIT = r.CIT,
                SPC = r.SPC,
                RTE = r.RTE,
                RLS = r.RLS,
                JMP = r.JMP,
                THP = r.THP,
                SAC = r.SAC,
                MAC = r.MAC,
                DAC = r.DAC,
                RUN = r.RUN,
                PAC = r.PAC,
                RBK = r.RBK,
                PBK = r.PBK,
                IBL = r.IBL,
                TAK = r.TAK,
                POW = r.POW,
                BSH = r.BSH,
                FMV = r.FMV,
                PMV = r.PMV,
                MCV = r.MCV,
                ZCV = r.ZCV,
                PRS = r.PRS,
                PRC = r.PRC,
                PUR = r.PUR
            });
            var vm = new PositionViewModel { Rookies = rookieList };
            //Takes the place of -> var vm = new PositionViewModel();
            //-> vm.Rookies = rookies;


            //make sure to update the view to use positionviewmodel
            return View(vm);
        }

        //you can use this as to populate a vm prop to set the title on the individual position views
        //try to group all of your public and private methods together for readability. try to avoid having public then private then public etc...
        private string GetPageMessage(Enums.Enums.PositionValue pageName)
        {
            return $"Your {pageName.GetDescription()} page";
        }

        [HttpGet]
        public IActionResult AddPlayer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPlayer(CreateViewModel player)
        {
            if (_context.Players.Any(p => p.PlayerName == player.PlayerName && p.Position == player.Position))
            {
                //Player name and position already exists
                //since you're checking the combination of the two
                //you can still use ivalidatableobject in the future when you get back to this
                ModelState.AddModelError(nameof(Player.PlayerName), "Player name already exists");
            }

            if (ModelState.IsValid)
            {
                var toCreate = new Player
                {
                    PlayerName = player.PlayerName,
                    Position = player.Position,
                    Age = player.Age,
                    Height = player.Height,
                    Weight = player.Weight,
                    Development = player.Development,
                    OVR = player.OVR,
                    SPD = player.SPD,
                    ACC = player.ACC,
                    STR = player.STR,
                    AGI = player.AGI,
                    ELU = player.ELU,
                    BCV = player.BCV,
                    CAR = player.CAR,
                    JKM = player.JKM,
                    SPM = player.SPM,
                    SFA = player.SFA,
                    TRK = player.TRK,
                    CTH = player.CTH,
                    CIT = player.CIT,
                    SPC = player.SPC,
                    RTE = player.RTE,
                    RLS = player.RLS,
                    JMP = player.JMP,
                    THP = player.THP,
                    SAC = player.SAC,
                    MAC = player.MAC,
                    DAC = player.DAC,
                    RUN = player.RUN,
                    PAC = player.PAC,
                    RBK = player.RBK,
                    PBK = player.PBK,
                    IBL = player.IBL,
                    TAK = player.TAK,
                    POW = player.POW,
                    BSH = player.BSH,
                    FMV = player.FMV,
                    PMV = player.PMV,
                    MCV = player.MCV,
                    ZCV = player.ZCV,
                    PRS = player.PRS,
                    PRC = player.PRC,
                    PUR = player.PUR
                };

                //it's usually a best practice to name your dbsets plural. Note: I mean dbset, not model. The model should be named Player, dbset: Players
                _context.Players.Add(toCreate);
                _context.Players.Add(toCreate);
                _context.SaveChanges();


                //idk why you used redirecttoaction, if there's a valid reason let me know.
                //imo, this line isn't even needed
                //redirecttoaction causes you to lose any modelstate validation errors. you just need to return the view
                return RedirectToAction("AddPlayer");
                //return Json(toCreate);
            }
            //you do not need to specify the name of the view since your action is now named properly. return View();
            return View("AddPlayer");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
