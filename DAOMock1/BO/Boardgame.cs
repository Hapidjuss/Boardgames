using Szewczyk.Boardgames.Core;
using Szewczyk.Boardgames.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szewczyk.Boardgames.DAOMock1.BO
{
    public class Boardgame : IBoardgame
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IAuthor Author { get; set; }
        public BoardgameType BoardgameType { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Author: {Author.FirstName} {Author.LastName}, Type: {BoardgameType} ";
        }
    }
}
