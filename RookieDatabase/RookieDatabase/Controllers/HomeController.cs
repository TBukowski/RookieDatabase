using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            // Is following 4 lines needed?
            //var positionTitle = new PositionViewModel
            //{
            //    PositionTitle = position
            //};
            var rookieList = _context.Players.Where(r => r.Position == position)
                                            .Select(r => new PositionDTO
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
  
            var vm = new PositionViewModel { Rookies = rookieList, PositionTitle = position };
           
            //Takes the place of -> var vm = new PositionViewModel();
            //-> vm.Rookies = rookies;
            return View(vm);
        }

        //you can use this as to populate a vm prop to set the title on the individual position views
        //try to group all of your public and private methods together for readability. try to avoid having public then private then public etc...
        private string GetPageMessage(Enums.Enums.PositionValue pageName)
        {
            return $"Your {pageName.GetDescription()} page";
        }

        //delete this? difference in get post?
        [HttpGet]
        public IActionResult AddPlayer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPlayer(PlayerAttributeViewModel player)
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
                _context.SaveChanges();


                //redirecttoaction causes you to lose any modelstate validation errors. you just need to return the view
                return View();
                //return Json(toCreate);
            }
            return View();
        }

        public IActionResult Edit(int? id, PlayerAttributeViewModel rookie)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toEdit = new Player
            {
                PlayerName = rookie.PlayerName,
                Position = rookie.Position,
                Age = rookie.Age,
                Height = rookie.Height,
                Weight = rookie.Weight,
                Development = rookie.Development,
                OVR = rookie.OVR,
                SPD = rookie.SPD,
                ACC = rookie.ACC,
                STR = rookie.STR,
                AGI = rookie.AGI,
                ELU = rookie.ELU,
                BCV = rookie.BCV,
                CAR = rookie.CAR,
                JKM = rookie.JKM,
                SPM = rookie.SPM,
                SFA = rookie.SFA,
                TRK = rookie.TRK,
                CTH = rookie.CTH,
                CIT = rookie.CIT,
                SPC = rookie.SPC,
                RTE = rookie.RTE,
                RLS = rookie.RLS,
                JMP = rookie.JMP,
                THP = rookie.THP,
                SAC = rookie.SAC,
                MAC = rookie.MAC,
                DAC = rookie.DAC,
                RUN = rookie.RUN,
                PAC = rookie.PAC,
                RBK = rookie.RBK,
                PBK = rookie.PBK,
                IBL = rookie.IBL,
                TAK = rookie.TAK,
                POW = rookie.POW,
                BSH = rookie.BSH,
                FMV = rookie.FMV,
                PMV = rookie.PMV,
                MCV = rookie.MCV,
                ZCV = rookie.ZCV,
                PRS = rookie.PRS,
                PRC = rookie.PRC,
                PUR = rookie.PUR
            };

            var player = _context.Players.SingleOrDefault(r => r.ID == id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RookieViewModel player)
        {
            //where context where id == id -see position action
                    _context.Update(player);
                    _context.SaveChanges();

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
