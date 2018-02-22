using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RookieDatabase.Data;
using RookieDatabase.Models;
using RookieDatabase.ViewModels;

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

            return View();
        }

        public IActionResult QB()
        {
            ViewData["Message"] = "Your QB page.";

            return View();
        }

        public IActionResult HB()
        {
            ViewData["Message"] = "Your HB page.";

            return View();
        }

        public IActionResult FB()
        {
            ViewData["Message"] = "Your FB page.";

            return View();
        }

        public IActionResult WR()
        {
            ViewData["Message"] = "Your WR page.";

            return View();
        }

        public IActionResult TE()
        {
            ViewData["Message"] = "Your TE page.";

            return View();
        }

        public IActionResult OL()
        {
            ViewData["Message"] = "Your OL page.";

            return View();
        }

        public IActionResult DE()
        {
            ViewData["Message"] = "Your DE page.";

            return View();
        }

        public IActionResult DT()
        {
            ViewData["Message"] = "Your DT page.";

            return View();
        }

        public IActionResult LB()
        {
            ViewData["Message"] = "Your LB page.";

            return View();
        }

        public IActionResult CB()
        {
            ViewData["Message"] = "Your CB page.";

            return View();
        }

        public IActionResult FS()
        {
            ViewData["Message"] = "Your FS page.";

            return View();
        }

        public IActionResult SS()
        {
            ViewData["Message"] = "Your SS page.";

            return View();
        }

        //[HttpPost("AddPlayer")]
        public IActionResult AddPlayer(CreateViewModel player)
        {
            if (_context.Player.Any(p => p.PlayerName == player.PlayerName))
            {
                if (_context.Player.Any(p => p.Position == player.Position))
                {
                    ModelState.AddModelError(nameof(Player.PlayerName), "Player name already exists");
                } 
            }

            if (ModelState.IsValid)
            {
                Player toCreate = new Player()
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
            return View("Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            var Rookies = _context.Player.ToList();
            var vm = new RookieViewModel()
            {
                //Rookies = Rookies.Select(r => new RookieViewModel
                //{

                //})
            };
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
