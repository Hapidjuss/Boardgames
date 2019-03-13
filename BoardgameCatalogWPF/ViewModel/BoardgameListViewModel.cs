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
    public class BoardgameListViewModel : ViewModelBase
    {
        public ObservableCollection<BoardgameViewModel> Boardgames { get; set; } = new ObservableCollection<BoardgameViewModel>();
        private ListCollectionView _view;

        private RelayCommand _filterDataCommand;
        public RelayCommand FilterDataCommand { get => _filterDataCommand; }

        private Szewczyk.Boardgames.BLC.BLC _blc;

        public string FilterValue { get; set; }

        public BoardgameListViewModel()
        {
            _blc = MainWindow.BLC;
            OnPropertyChanged("Boardgames");
            GetAllBoardgames();
            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(Boardgames);
            _filterDataCommand = new RelayCommand(param => this.FilterData());
            _addNewBoardgameCommand = new RelayCommand(param => this.AddNewBoardgame(),
                                                        param => this.CanAddNewBoardgame());
            _saveBoardgameCommand = new RelayCommand(param => this.SaveBoardgame(),
                                                        param => this.CanSaveBoardgame());
            _deleteBoardgameCommand = new RelayCommand(param => this.DeleteBoardgame(),
                                                        param => this.CanDeleteBoardgame());
        }

        private void GetAllBoardgames()
        {
            foreach(var boardgame in _blc.GetBoardgames())
            {
                Boardgames.Add(new BoardgameViewModel(boardgame, (List<IAuthor>)_blc.GetAuthors()));
            }
        }

        private void FilterData()
        {
            if(string.IsNullOrEmpty(FilterValue))
            {
                _view.Filter = null;
            }
            else
            {
                _view.Filter = (b) => ((BoardgameViewModel)b).Name.Contains(FilterValue);
            }
        }

        private BoardgameViewModel _editedBoardgame;
        public BoardgameViewModel EditedBoardgame
        {
            get => _editedBoardgame;
            set
            {
                _editedBoardgame = value;
                OnPropertyChanged(nameof(EditedBoardgame));
            }
        }

        private void AddNewBoardgame()
        {
            EditedBoardgame = new BoardgameViewModel(_blc.addNewBoardgame(), (List<IAuthor>)_blc.GetAuthors());
            EditedBoardgame.ID = _blc.GetBoardgames().Count() + 1;
            EditedBoardgame.Name = "";
            EditedBoardgame.Author = null;
            EditedBoardgame.BoardgameType = Szewczyk.Boardgames.Core.BoardgameType.Other;
            EditedBoardgame.Validate();
        }

        private RelayCommand _addNewBoardgameCommand;

        public RelayCommand AddNewBoardgameCommand
        {
            get => _addNewBoardgameCommand;
        }

        private bool CanAddNewBoardgame()
        {
            return true;
        }

        private RelayCommand _saveBoardgameCommand;

        public RelayCommand SaveBoardgameCommand
        {
            get => _saveBoardgameCommand;
        }

        private void SaveBoardgame()
        {
            Boardgames.Add(EditedBoardgame);
            _blc.saveBoardgame(EditedBoardgame.Boardgame);
        }

        private bool CanSaveBoardgame()
        {
            if((EditedBoardgame != null) && !EditedBoardgame.HasErrors && !Boardgames.Contains(EditedBoardgame))
            {
                return true;
            }
            return false;
        }

        private RelayCommand _deleteBoardgameCommand;

        public RelayCommand DeleteBoardgameCommand
        {
            get => _deleteBoardgameCommand;
        }

        private void DeleteBoardgame()
        {
            _blc.deleteBoardgame(EditedBoardgame.Boardgame);
            Boardgames.Remove(EditedBoardgame);
        }

        private bool CanDeleteBoardgame()
        {
            if((EditedBoardgame != null) && Boardgames.Contains(EditedBoardgame))
            {
                return true;
            }
            return false;
        }

        public bool IsDirty
        {
            get; set;
        }
/*
        private void CreateEmptyBoardgame(object o)
        {
            IBoardgame boardgame = blc.CreateEmptyBoardgame();
            BoardgameViewModel bvm = new BoardgameViewModel(boardgame);
            boardgames.Add(bvm);
            SelectedBoardgame = bvm;
        }

        private RelayCommand createEmptyBoardgameCommand;

        public RelayCommand CreateEmptyBoardgameCommand
        {
            get => createEmptyBoardgameCommand;
        }

        private BoardgameViewModel selectedBoardgame;

        public BoardgameViewModel SelectedBoardgame
        {
            get => selectedBoardgame;
            set
            {
                selectedBoardgame = value;
                OnPropertyChanged(nameof(SelectedBoardgame));
            }
        }

        private ObservableCollection<IAuthor> authors;

        public ObservableCollection<IAuthor> Authors
        {
            get => authors;
        }
 */   }
}
