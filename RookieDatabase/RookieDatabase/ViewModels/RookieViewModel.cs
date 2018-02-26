using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RookieDatabase.Models;
using static RookieDatabase.Enums.Enums;

namespace RookieDatabase.ViewModels
{
    public class RookieViewModel
    {
        public int ID { get; set; }
        public string PlayerName { get; set; }
        public string Position { get; set; }
        //public PositionValue PositionValue { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Development { get; set; }
        public int OVR { get; set; }
        public int SPD { get; set; }
        public int ACC { get; set; }
        public int STR { get; set; }
        public int AGI { get; set; }
        public int ELU { get; set; }
        public int BCV { get; set; }
        public int CAR { get; set; }
        public int JKM { get; set; }
        public int SPM { get; set; }
        public int SFA { get; set; }
        public int TRK { get; set; }
        public int CTH { get; set; }
        public int CIT { get; set; }
        public int SPC { get; set; }
        public int RTE { get; set; }
        public int RLS { get; set; }
        public int JMP { get; set; }
        public int THP { get; set; }
        public int SAC { get; set; }
        public int MAC { get; set; }
        public int DAC { get; set; }
        public int RUN { get; set; }
        public int PAC { get; set; }
        public int RBK { get; set; }
        public int PBK { get; set; }
        public int IBL { get; set; }
        public int TAK { get; set; }
        public int POW { get; set; }
        public int BSH { get; set; }
        public int FMV { get; set; }
        public int PMV { get; set; }
        public int MCV { get; set; }
        public int ZCV { get; set; }
        public int PRS { get; set; }
        public int PRC { get; set; }
        public int PUR { get; set; }
        //-------------------------------------------------------------------------------------------------
        //the code here is similar to line 42 in my homecontroller. Not sure where to put it or how to label it
        //-------------------------------------------------------------------------------------------------
        public enum Positions { get; set; }
        //public Player Player { get; set; }
        //public ICollection<Player> Rookies { get; set;}
    }
}
