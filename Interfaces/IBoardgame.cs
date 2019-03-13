using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szewczyk.Boardgames.Interfaces
{
    public interface IBoardgame
    {
        int ID { get; set; }
        string Name { get; set; }
        IAuthor Author { get; set; }
        Szewczyk.Boardgames.Core.BoardgameType BoardgameType { get; set; }
    }
}
