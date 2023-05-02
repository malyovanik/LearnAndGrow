using LearnAndGrow.Commands;
using LearnAndGrow.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearnAndGrow.ViewModel.Childs
{
    internal class AddNewWordViewModel : BaseViewModel
    {

        public AddNewWordViewModel() { }
        private ICommand _addWordInVocabularyCommand;

        public ICommand AddWordInVocabularyCommand
        {
            get
            {
                if (_addWordInVocabularyCommand == null)
                {
                    _addWordInVocabularyCommand = new RelayCommand(param => AddWordCommand());
                }
                return _addWordInVocabularyCommand;
            }
        }

        private void AddWordCommand()
        {

        }
    }
}
