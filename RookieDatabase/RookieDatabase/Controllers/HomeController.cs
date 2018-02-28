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
            var vm = new PositionViewModel();
            var rookieList = _context.Player.ToList();
            var rookies = rookieList.Select(r => new PositionDTO
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
            vm.Rookies = rookies;

            return View(vm);
        }

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
            if (_context.Player.Any(p => p.PlayerName == player.PlayerName && p.Position == player.Position))
            {
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

                _context.Player.Add(toCreate);
                _context.SaveChanges();

                return RedirectToAction("AddPlayer");
                //return Json(toCreate);
            }
            return View("AddPlayer");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
