using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildRoutes
{
    public class Path
    {
        public string From;
        public string To;

        public Path(string from, string to)
        {
            From = from;
            To = to;
        }
    }
}
