using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szewczyk.Boardgames.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IAuthor> GetAllAuthors();
        IEnumerable<IBoardgame> GetAllBoardgames();
        IBoardgame CreateEmptyBoardgame();
        IBoardgame AddNewBoardgame();
        IAuthor AddNewAuthor();
        void SaveBoardgame(IBoardgame boardgame);
        void SaveAuthor(IAuthor author);
        void DeleteBoardgame(IBoardgame boardgame);
        void DeleteAuthor(IAuthor author);
    }
}
