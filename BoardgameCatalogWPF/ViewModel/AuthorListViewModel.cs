using Szewczyk.Boardgames.Interfaces;
using Szewczyk.Boardgames.BLC;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Szewczyk.Boardgames.GUI.ViewModel
{
    public class AuthorListViewModel : ViewModelBase
    {
        public ObservableCollection<AuthorViewModel> Authors { get; set; } = new ObservableCollection<AuthorViewModel>();
        private ListCollectionView _view;

        private RelayCommand _filterDataCommand;
        public RelayCommand FilterDataCommand { get => _filterDataCommand; }

        private Szewczyk.Boardgames.BLC.BLC _blc;

        public string FilterValue { get; set; }

        public AuthorListViewModel()
        {
            _blc = MainWindow.BLC;
            OnPropertyChanged("Authors");
            GetAllAuthors();
            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(Authors);
            _filterDataCommand = new RelayCommand(param => this.FilterData());
            _addNewAuthorCommand = new RelayCommand(param => this.AddNewAuthor(),
                                                        param => this.CanAddNewAuthor());
            _saveAuthorCommand = new RelayCommand(param => this.SaveAuthor(),
                                                        param => this.CanSaveAuthor());
            _deleteAuthorCommand = new RelayCommand(param => this.DeleteAuthor(),
                                                        param => this.CanDeleteAuthor());
        }

        private void GetAllAuthors()
        {
            foreach (var author in _blc.GetAuthors())
            {
                Authors.Add(new AuthorViewModel(author));
            }
        }

        private void FilterData()
        {
            if (string.IsNullOrEmpty(FilterValue))
            {
                _view.Filter = null;
            }
            else
            {
                _view.Filter = (a) => ((AuthorViewModel)a).LastName.Contains(FilterValue);
            }
        }

        private AuthorViewModel _editedAuthor;
        public AuthorViewModel EditedAuthor
        {
            get => _editedAuthor;
            set
            {
                _editedAuthor = value;
                OnPropertyChanged(nameof(EditedAuthor));
            }
        }

        private void AddNewAuthor()
        {
            EditedAuthor = new AuthorViewModel(_blc.addNewAuthor());
            EditedAuthor.ID = _blc.GetAuthors().Count() + 1;
            EditedAuthor.FirstName = "";
            EditedAuthor.LastName = "";
            EditedAuthor.Validate();
        }

        private RelayCommand _addNewAuthorCommand;

        public RelayCommand AddNewAuthorCommand
        {
            get => _addNewAuthorCommand;
        }

        private bool CanAddNewAuthor()
        {
            return true;
        }

        private RelayCommand _saveAuthorCommand;

        public RelayCommand SaveAuthorCommand
        {
            get => _saveAuthorCommand;
        }

        private void SaveAuthor()
        {
            Authors.Add(EditedAuthor);
            _blc.saveAuthor(EditedAuthor.Author);
        }

        private bool CanSaveAuthor()
        {
            if ((EditedAuthor != null) && !EditedAuthor.HasErrors && !Authors.Contains(EditedAuthor))
            {
                return true;
            }
            return false;
        }

        private RelayCommand _deleteAuthorCommand;

        public RelayCommand DeleteAuthorCommand
        {
            get => _deleteAuthorCommand;
        }

        private void DeleteAuthor()
        {
            _blc.deleteAuthor(EditedAuthor.Author);
            Authors.Remove(EditedAuthor);
        }

        private bool CanDeleteAuthor()
        {
            if ((EditedAuthor != null) && Authors.Contains(EditedAuthor))
            {
                return true;
            }
            return false;
        }

        public bool IsDirty
        {
            get; set;
        }
    }
}
