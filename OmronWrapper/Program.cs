using System;
using System.Net;
using System.Security;
using System.Linq;
using System.Collections.Generic;

namespace OmronWrapper
{
    class Program
    {
        static ARCLConnection generalConnection;
        static List<Fleet> lTotalFleet = new List<Fleet>();
        static void Main(string[] args)
        {
            generalConnection = new ARCLConnection(IPAddress.Parse("127.0.0.1"), 9999,"password".ToSecureString());
            Fleet f1 = new Fleet(1, generalConnection);
            Fleet f2 = new Fleet(2, generalConnection);
            Fleet f3 = new Fleet(3, generalConnection);
        }

        public async void gatherAllFleets()
        {
            foreach(Fleet f in lTotalFleet)
            {
                await f.con.sendCommand("doTaskInstant moveToGatheringPoint");
            }
        }
    }
}
