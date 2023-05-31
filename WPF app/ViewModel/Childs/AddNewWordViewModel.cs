using LearnAndGrow.Commands;
using LearnAndGrow.Utilities;
using System.Windows.Input;

namespace LearnAndGrow.ViewModel.Childs
{
    internal class AddNewWordViewModel : BaseViewModel
    {
        private string _wordInForeignLanguage;
        private string _wordInNativeLanguage;

        public string WordInForeignLanguage
        {
            get { return _wordInForeignLanguage; }
            set
            {
                _wordInForeignLanguage = value;
                OnPropertyChanged();
            }
        }

        public string WordInNativeLanguage
        {
            get { return _wordInNativeLanguage; }
            set
            {
                _wordInNativeLanguage = value;
                OnPropertyChanged();
            }
        }

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
            Vocabulary.AddWord(new Word(WordInForeignLanguage, WordInNativeLanguage));
        }
    }
}