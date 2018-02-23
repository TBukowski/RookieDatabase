using System.ComponentModel;

namespace RookieDatabase.Enums
{
    public class Enums
    {
        public enum PositionValue
        {
            [Description("Cornerback")]
            CB,
            [Description("Defensive End")]
            DE,
            [Description("Defensive Tackle")]
            DT,
            [Description("Fullback")]
            FB,
            [Description("Free Safety")]
            FS,
            [Description("Halfback")]
            HB,
            [Description("Linebacker")]
            LB,
            [Description("Offensive Lineman")]
            OL,
            [Description("Quarterback")]
            QB,
            [Description("Strong Safety")]
            SS,
            [Description("Tight End")]
            TE,
            [Description("Wide Receiver")]
            WR
        }
    }
}
