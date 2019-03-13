using Szewczyk.Boardgames.Core;
using Szewczyk.Boardgames.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szewczyk.Boardgames.GUI.ViewModel
{
    public class BoardgameViewModel : ViewModelBase
    {
        private IBoardgame _boardgame;
        public IBoardgame Boardgame { get => _boardgame; }

        public BoardgameViewModel(IBoardgame boardgame, List<IAuthor> listAuthors)
        {
            _boardgame = boardgame;
            _authors = new ObservableCollection<IAuthor>(listAuthors);
        }

        [Required(ErrorMessage = "You need to set ID.")]
        public int ID
        {
            get => _boardgame.ID;
            set
            {
                _boardgame.ID = value;
                Validate();
                OnPropertyChanged(nameof(ID));
            }
        }

        [Required(ErrorMessage = "You need to set Boardgame Name.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Boardgame Name should have lenght in range.")]
        public string Name
        {
            get => _boardgame.Name;
            set
            {
                _boardgame.Name = value;
                Validate();
                OnPropertyChanged(nameof(Name));
            }
        }

        [Required(ErrorMessage = "You need to set Boardgame Author.")]
        public IAuthor Author
        {
            get => _boardgame.Author;
            set
            {
                _boardgame.Author = value;
                Validate();
                OnPropertyChanged(nameof(Author));
            }
        }

        private ObservableCollection<IAuthor> _authors;

        public ObservableCollection<IAuthor> Authors
        {
            get => _authors;
        }

        [Required(ErrorMessage = "You need to set Boardgame Type.")]
        public Szewczyk.Boardgames.Core.BoardgameType BoardgameType
        {
            get => _boardgame.BoardgameType;
            set
            {
                _boardgame.BoardgameType = value;
                OnPropertyChanged(nameof(BoardgameType));
            }
        }

        public void Validate()
        {
            var validationContext = new ValidationContext(this, null, null);
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(this, validationContext, validationResults, true);

            foreach(var kv in _errors.ToList())
            {
                if(validationResults.All(r => r.MemberNames.All(m => m != kv.Key)))
                {
                    _errors.Remove(kv.Key);
                    RaiseErrorChanged(kv.Key);
                }
            }

            var q = from r in validationResults
                    from m in r.MemberNames
                    group r by m into g
                    select g;

            foreach(var prop in q)
            {
                var messages = prop.Select(r => r.ErrorMessage).ToList();

                if(_errors.ContainsKey(prop.Key))
                {
                    _errors.Remove(prop.Key);
                }
                _errors.Add(prop.Key, messages);

                RaiseErrorChanged(prop.Key);
            }
        }
    }
}
