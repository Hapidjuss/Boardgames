using Szewczyk.Boardgames.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szewczyk.Boardgames.DAOMock2
{
    public class DB : IDAO
    {
        private List<IAuthor> _authors;
        private List<IBoardgame> _boardgames;

        public DB()
        {
            _authors = new List<IAuthor>()
            {
                new BO.Author{ ID=1, FirstName="Frederick", LastName="Moyersoen" },
                new BO.Author{ ID=2, FirstName="Antoine", LastName="Bauza" },
                new BO.Author{ ID=3, FirstName="Emiliano", LastName="Sciarra" },
                new BO.Author{ ID=4, FirstName="Reiner", LastName="Knizia" }
            };

            _boardgames = new List<IBoardgame>()
            {
                new BO.Boardgame
                {
                    ID = 1,
                    Name = "Sabotażysta",
                    Author = _authors[0],
                    BoardgameType = Szewczyk.Boardgames.Core.BoardgameType.Cards
                },
                new BO.Boardgame
                {
                    ID = 2,
                    Name = "Sabotażysta Rozszerzenie",
                    Author = _authors[0],
                    BoardgameType = Szewczyk.Boardgames.Core.BoardgameType.Cards
                },
                new BO.Boardgame
                {
                    ID = 3,
                    Name = "7 Cudów Świata",
                    Author = _authors[1],
                    BoardgameType = Szewczyk.Boardgames.Core.BoardgameType.Cards
                },
                new BO.Boardgame
                {
                    ID = 4,
                    Name = "BANG!",
                    Author = _authors[2],
                    BoardgameType = Szewczyk.Boardgames.Core.BoardgameType.Cards
                },
                new BO.Boardgame
                {
                    ID = 5,
                    Name = "Pędzące Żółwie",
                    Author = _authors[3],
                    BoardgameType = Szewczyk.Boardgames.Core.BoardgameType.Party
                }
            };
        }

        public IBoardgame CreateEmptyBoardgame()
        {
            return new BO.Boardgame();
        }

        public IBoardgame AddNewBoardgame()
        {
            BO.Boardgame boardgame = new BO.Boardgame();
            boardgame.ID = 0;
            boardgame.Name = "";
            return (IBoardgame)boardgame;
        }

        public IAuthor AddNewAuthor()
        {
            BO.Author author = new BO.Author();
            author.ID = 0;
            author.FirstName = "";
            author.LastName = "";
            return (IAuthor)author;
        }

        public void SaveBoardgame(IBoardgame boardgame)
        {
            if (!_boardgames.Contains(boardgame))
            {
                _boardgames.Add(boardgame);
            }
        }

        public void SaveAuthor(IAuthor author)
        {
            if (!_authors.Contains(author))
            {
                _authors.Add(author);
            }
        }

        public void DeleteBoardgame(IBoardgame boardgame)
        {
            if (_boardgames.Contains(boardgame))
            {
                _boardgames.Remove(boardgame);
            }
        }

        public void DeleteAuthor(IAuthor author)
        {
            if (_authors.Contains(author))
            {
                _authors.Remove(author);
            }
        }

        public IEnumerable<IBoardgame> GetAllBoardgames()
        {
            return _boardgames;
        }

        public IEnumerable<IAuthor> GetAllAuthors()
        {
            return _authors;
        }
    }
}
