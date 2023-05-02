using LearnAndGrow.Commands;
using LearnAndGrow.Model;
using LearnAndGrow.Model.Childs;
using LearnAndGrow.Utilities;
using LearnAndGrow.ViewModel.Childs;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace LearnAndGrow.ViewModel
{
    public class LearnAndGrowViewModel : BaseViewModel
    {

        private BaseViewModel _selectedViewModel = new WelcomeViewModel();
        private ICommand _updateViewCommand;

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand UpdateViewCommand
        {
            get
            {
                if (_updateViewCommand == null)
                {
                    _updateViewCommand = new RelayCommand(param => UpdateView(param));
                }
                return _updateViewCommand;
            }
        }

        private void UpdateView(object ob)
        {
            if(ob.ToString() == "Welcome")
            {
                SelectedViewModel = new WelcomeViewModel();
            }
            else if(ob.ToString() == "Next")
            {
                var model = new LearnNewWordsModel();
                SelectedViewModel = new LearnNewWordsViewModel(model);             
            }
            else if(ob.ToString() == "AddNewWord")
            {
                SelectedViewModel = new AddNewWordViewModel();
            }

        }

        private readonly LearnAndGrowModel _model;
        public LearnAndGrowViewModel(LearnAndGrowModel model)
        {
            _model = model;
        }
    }
}