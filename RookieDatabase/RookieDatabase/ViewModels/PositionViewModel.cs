using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieDatabase.ViewModels
{
    public class PositionViewModel
    {
        public string PositionTitle { get; set; }
        public IEnumerable<PositionDTO> Rookies { get; set; }
    }
}
