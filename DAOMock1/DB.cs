using Szewczyk.Boardgames.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szewczyk.Boardgames.DAOMock1
{
    public class DB : IDAO
    {
        private List<IAuthor> _authors;
        private List<IBoardgame> _boardgames;

        public DB()
        {
            _authors = new List<IAuthor>()
            {
                new BO.Author{ ID=1, FirstName="Christian T.", LastName="Petersen" },
                new BO.Author{ ID=2, FirstName="Martin", LastName="Wallace" },
                new BO.Author{ ID=3, FirstName="Klaus", LastName="Teuber" },
                new BO.Author{ ID=4, FirstName="Vlaada", LastName="Chvatil" },
                new BO.Author{ ID=5, FirstName="Bruno", LastName="Faidutti" }
            };

            _boardgames = new List<IBoardgame>()
            {
                new BO.Boardgame
                {
                    ID = 1,
                    Name = "Gra o Tron, Druga Edycja",
                    Author = _authors[0],
                    BoardgameType = Szewczyk.Boardgames.Core.BoardgameType.Strategy
                },
                new BO.Boardgame
                {
                    ID = 2,
                    Name = "Świat Dysku Ankh-Morpork",
                    Author = _authors[1],
                    BoardgameType = Szewczyk.Boardgames.Core.BoardgameType.Strategy
                },
                new BO.Boardgame
                {
                    ID = 3,
                    Name = "Osadnicy z Catanu",
                    Author = _authors[2],
                    BoardgameType = Szewczyk.Boardgames.Core.BoardgameType.Strategy
                },
                new BO.Boardgame
                {
                    ID = 4,
                    Name = "Gra o Tron, Pierwsza Edycja",
                    Author = _authors[0],
                    BoardgameType = Szewczyk.Boardgames.Core.BoardgameType.Strategy
                },
                new BO.Boardgame
                {
                    ID = 5,
                    Name = "Tajniacy",
                    Author = _authors[3],
                    BoardgameType = Szewczyk.Boardgames.Core.BoardgameType.Party
                },
                new BO.Boardgame
                {
                    ID = 6,
                    Name = "Tajniacy Obrazki",
                    Author = _authors[3],
                    BoardgameType = Szewczyk.Boardgames.Core.BoardgameType.Party
                },
                new BO.Boardgame
                {
                    ID = 7,
                    Name = "Cytadela",
                    Author = _authors[4],
                    BoardgameType = Szewczyk.Boardgames.Core.BoardgameType.Cards
                },
                new BO.Boardgame
                {
                    ID = 8,
                    Name = "Maskarada",
                    Author = _authors[4],
                    BoardgameType = Szewczyk.Boardgames.Core.BoardgameType.Cards
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
            if(!_boardgames.Contains(boardgame))
            {
                _boardgames.Add(boardgame);
            }
        }

        public void SaveAuthor(IAuthor author)
        {
            if(!_authors.Contains(author))
            {
                _authors.Add(author);
            }
        }

        public void DeleteBoardgame(IBoardgame boardgame)
        {
            if(_boardgames.Contains(boardgame))
            {
                _boardgames.Remove(boardgame);
            }
        }

        public void DeleteAuthor(IAuthor author)
        {
            if(_authors.Contains(author))
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
