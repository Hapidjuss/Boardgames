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
    public class AuthorViewModel : ViewModelBase
    {
        private IAuthor _author;
        public IAuthor Author { get => _author; }

        public AuthorViewModel(IAuthor author)
        {
            _author = author;
        }

        [Required(ErrorMessage = "You need to set ID.")]
        public int ID
        {
            get => _author.ID;
            set
            {
                _author.ID = value;
                Validate();
                OnPropertyChanged(nameof(ID));
            }
        }

        [Required(ErrorMessage = "You need to set Author First Name.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Author First Name should have lenght in range.")]
        public string FirstName
        {
            get => _author.FirstName;
            set
            {
                _author.FirstName = value;
                Validate();
                OnPropertyChanged(nameof(FirstName));
            }
        }

        [Required(ErrorMessage = "You need to set Author Last Name.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Author Last Name should have lenght in range.")]
        public string LastName
        {
            get => _author.LastName;
            set
            {
                _author.LastName = value;
                Validate();
                OnPropertyChanged(nameof(LastName));
            }
        }

        public void Validate()
        {
            var validationContext = new ValidationContext(this, null, null);
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(this, validationContext, validationResults, true);

            foreach (var kv in _errors.ToList())
            {
                if (validationResults.All(r => r.MemberNames.All(m => m != kv.Key)))
                {
                    _errors.Remove(kv.Key);
                    RaiseErrorChanged(kv.Key);
                }
            }

            var q = from r in validationResults
                    from m in r.MemberNames
                    group r by m into g
                    select g;

            foreach (var prop in q)
            {
                var messages = prop.Select(r => r.ErrorMessage).ToList();

                if (_errors.ContainsKey(prop.Key))
                {
                    _errors.Remove(prop.Key);
                }
                _errors.Add(prop.Key, messages);

                RaiseErrorChanged(prop.Key);
            }
        }
    }
}
