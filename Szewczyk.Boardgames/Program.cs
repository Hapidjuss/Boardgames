using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Szewczyk.Boardgames
{
    class Program
    {
        static void Main(string[] args)
        {
            Properties.Settings sett = new Properties.Settings();
            Szewczyk.Boardgames.BLC.BLC blc = new Szewczyk.Boardgames.BLC.BLC(sett.dbNameConf);

            foreach(var auth in blc.GetAuthors())
            {
                Console.WriteLine(auth);
            }

            Console.WriteLine("#########");
            foreach(var boardgame in blc.GetBoardgames())
            {
                Console.WriteLine(boardgame);
            }

            Thread.Sleep(5000);
        }
    }
}
