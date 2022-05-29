using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmronWrapper
{
    public class Fleet
    {
        public ARCLConnection con;
        public int identifier { get; set; }

        public Fleet(int _identifier, ARCLConnection con)
        {
            identifier = _identifier;
        }
    }
}
