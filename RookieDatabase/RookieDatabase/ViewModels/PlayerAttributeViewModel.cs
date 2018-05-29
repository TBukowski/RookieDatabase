using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RookieDatabase.Models;

namespace RookieDatabase.ViewModels
{
    public class PlayerAttributeViewModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Player Name")]
        public string PlayerName { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public string Development { get; set; }
        [Range(0,99)]
        public int OVR { get; set; }
        [Range(0,99)]
        public int SPD { get; set; }
        [Range(0,99)]
        public int ACC { get; set; }
        [Range(0,99)]
        public int STR { get; set; }
        [Range(0,99)]
        public int AGI { get; set; }
        [Range(0,99)]
        public int ELU { get; set; }
        [Range(0,99)]
        public int BCV { get; set; }
        [Range(0,99)]
        public int CAR { get; set; }
        [Range(0,99)]
        public int JKM { get; set; }
        [Range(0,99)]
        public int SPM { get; set; }
        [Range(0,99)]
        public int SFA { get; set; }
        [Range(0,99)]
        public int TRK { get; set; }
        [Range(0,99)]
        public int CTH { get; set; }
        [Range(0,99)]
        public int CIT { get; set; }
        [Range(0,99)]
        public int SPC { get; set; }
        [Range(0,99)]
        public int RTE { get; set; }
        [Range(0,99)]
        public int RLS { get; set; }
        [Range(0,99)]
        public int JMP { get; set; }
        [Range(0,99)]
        public int THP { get; set; }
        [Range(0,99)]
        public int SAC { get; set; }
        [Range(0,99)]
        public int MAC { get; set; }
        [Range(0,99)]
        public int DAC { get; set; }
        [Range(0,99)]
        public int RUN { get; set; }
        [Range(0,99)]
        public int PAC { get; set; }
        [Range(0,99)]
        public int RBK { get; set; }
        [Range(0,99)]
        public int PBK { get; set; }
        [Range(0,99)]
        public int IBL { get; set; }
        [Range(0,99)]
        public int TAK { get; set; }
        [Range(0,99)]
        public int POW { get; set; }
        [Range(0,99)]
        public int BSH { get; set; }
        [Range(0,99)]
        public int FMV { get; set; }
        [Range(0,99)]
        public int PMV { get; set; }
        [Range(0,99)]
        public int MCV { get; set; }
        [Range(0,99)]
        public int ZCV { get; set; }
        [Range(0,99)]
        public int PRS { get; set; }
        [Range(0,99)]
        public int PRC { get; set; }
        [Range(0,99)]
        public int PUR { get; set; }
    }
}

