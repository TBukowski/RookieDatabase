using System.ComponentModel;

namespace RookieDatabase.Enums
{
    public class Enums
    {
        public enum PositionValue
        {
            [Description("Quarterback")]
            QB,
            [Description("Halfback")]
            HB,
            [Description("Fullback")]
            FB,
            [Description("Wide Receiver")]
            WR,
            [Description("Tight End")]
            TE,
            [Description("Offensive Lineman")]
            OL,
            [Description("Defensive End")]
            DE,
            [Description("Defensive Tackle")]
            DT,
            [Description("Linebacker")]
            LB,
            [Description("Cornerback")]
            CB,
            [Description("Free Safety")]
            FS,
            [Description("Strong Safety")]
            SS
        }
    }
}
