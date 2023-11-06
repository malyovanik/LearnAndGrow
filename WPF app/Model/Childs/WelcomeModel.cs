using LearnAndGrow.Utilities;

namespace LearnAndGrow.Model.Childs
{
    public class WelcomeModel: BaseViewModel
    {
        private int _countWords ;



        public int CountWords
        {
            get { return _countWords; }

            set
            {
                _countWords = value;
                OnPropertyChanged();
            }

        }
        
        public void ShowWorrdsCount()
        {
            CountWords = 5; 
        }
    }


}