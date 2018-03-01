using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieDatabase.ViewModels
{
    public class PositionViewModel
    {
        //add line for singular position for title of posistion page
        public IEnumerable<PositionDTO> Rookies { get; set; }
    }
}
