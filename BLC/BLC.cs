using Szewczyk.Boardgames.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Szewczyk.Boardgames.BLC
{
    public class BLC
    {
        private IDAO dao;

        public BLC(string dbName)
        {
            Assembly a = Assembly.UnsafeLoadFrom(dbName);

            Type daoToCreate = null;
            Type daoType = typeof(IDAO);

            foreach(var t in a.GetTypes())
            {
                foreach (var i in t.GetInterfaces())
                {
                    if (i == daoType)
                    {
                        daoToCreate = t;
                    }
                }
            }
            dao = (IDAO)Activator.CreateInstance(daoToCreate, new object[] { });
        }

        public IEnumerable<IBoardgame> GetBoardgames()
        {
            return dao.GetAllBoardgames();
        }

        public IEnumerable<IAuthor> GetAuthors()
        {
            return dao.GetAllAuthors();
        }

        public IBoardgame CreateEmptyBoardgame()
        {
            return dao.CreateEmptyBoardgame();
        }

        public IBoardgame addNewBoardgame()
        {
            return dao.AddNewBoardgame();
        }

        public IAuthor addNewAuthor()
        {
            return dao.AddNewAuthor();
        }

        public void saveBoardgame(IBoardgame boardgame)
        {
            dao.SaveBoardgame(boardgame);
        }

        public void saveAuthor(IAuthor author)
        {
            dao.SaveAuthor(author);
        }

        public void deleteBoardgame(IBoardgame boardgame)
        {
            dao.DeleteBoardgame(boardgame);
        }

        public void deleteAuthor(IAuthor author)
        {
            dao.DeleteAuthor(author);
        }
    }
}
