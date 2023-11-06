using LearnAndGrow.Utilities;
using System.Linq;
using System.Threading;

namespace LearnAndGrow.ViewModel.Childs
{
    public class WelcomeViewModel : BaseViewModel
    {
        public WelcomeViewModel()
        {
         _countWords=Count.ShowCount();
         _countLearned=Count.ShowCountRightAnswer();
         _countNotLearned=Count.ShowCountLeftAnswer();
        }  
        private int _countWords; 
        private int _countLearned;
        private int _countNotLearned;
        Vocabulary Count = new Vocabulary();    
              
        public int CountWords
        {
            get { return _countWords; }

            set
            {
                _countWords = value;
                OnPropertyChanged();
            }

        }
        public int CountWordsLearned
        {
            get { return _countLearned; }

            set
            {
                _countLearned = value;
                OnPropertyChanged();
            }

        }
        public int CountWordsNotLearned
        {
            get { return _countNotLearned; }

            set
            {
                _countNotLearned = value;
                OnPropertyChanged();
            }

        }



    }

}