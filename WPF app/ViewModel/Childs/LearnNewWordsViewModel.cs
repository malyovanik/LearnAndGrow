using LearnAndGrow.Commands;
using LearnAndGrow.Model.Childs;
using LearnAndGrow.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;


namespace LearnAndGrow.ViewModel.Childs
{
    public class LearnNewWordsViewModel : BaseViewModel
    {
        
        
        private int _correctButtonIndex ;
        private int _curentAnswer ;
        private int _incurentAnswer;
        private string _firstWord;
        private string _secondWord;
        private string _thirdWord;
        private string _fourWord;
        private readonly LearnNewWordsModel _model;
        private string _currentWordTranslation;
        private Word _currentWord;          
        private RelayCommand _selectWordCommand;
        public string _showMessage  ;
        private readonly object showMessageLock = new object();
        private Brush buttonBackground1 = Brushes.Gray;
        private Brush buttonBackground2 = Brushes.Gray;
        private Brush buttonBackground3 = Brushes.Gray;
        private Brush buttonBackground4 = Brushes.Gray;


        public Brush ButtonBackground1
        {
            get { return buttonBackground1; }
            set
            {
                if (buttonBackground1 != value)
                {
                    buttonBackground1 = value;
                    OnPropertyChanged(nameof(ButtonBackground1));
                }
            }
        }

        public Brush ButtonBackground2
        {
            get { return buttonBackground2; }
            set
            {
                if (buttonBackground2 != value)
                {
                    buttonBackground2 = value;
                    OnPropertyChanged(nameof(ButtonBackground2));
                }
            }
        }

        public Brush ButtonBackground3
        {
            get { return buttonBackground3; }
            set
            {
                if (buttonBackground3 != value)
                {
                    buttonBackground3 = value;
                    OnPropertyChanged(nameof(ButtonBackground3));
                }
            }
        }

        public Brush ButtonBackground4
        {
            get { return buttonBackground4; }
            set
            {
                if (buttonBackground4 != value)
                {
                    buttonBackground4 = value;
                    OnPropertyChanged(nameof(ButtonBackground4));
                }
            }
        }
        public ICommand SelectWordCommand
        {
            get
            {
                if (_selectWordCommand == null)
                {
                    _selectWordCommand = new RelayCommand(async param => await AnswerSelectedCommandAsync(param));
                }
                return _selectWordCommand;
            }
        }


        private async Task AnswerSelectedCommandAsync(object selectedWord)
        {
            bool curentButton = false;  
            if (CurrentWord.WordName == FirstWord)
            {
                _correctButtonIndex = 1;

            }
          else  if (CurrentWord.WordName == SecondWord)
            {
                _correctButtonIndex = 2;

            }
          else  if (CurrentWord.WordName == ThirdWord)
            {
                _correctButtonIndex = 3;

            }
           else if (CurrentWord.WordName == FourWord)
            {
                _correctButtonIndex = 4;

            }

            if (selectedWord.ToString() == "First button")
            {
                if (CurrentWord.WordName == FirstWord)
                {
                   
                    curentButton=true;
                    
                    ButtonBackground1 = Brushes.Green;                                          
                    await Task.Delay(1000);
                    ButtonBackground1 = Brushes.Gray;
                    CurentAnswer++;
                }
                else
                {
                    
                    ButtonBackground1 = Brushes.Red;       
                    await Task.Delay(1000);                   
                    ButtonBackground1 = Brushes.Gray;
                    IncurentAnswer++;
                   
                  
                }
            }
            else if (selectedWord.ToString() == "Second button")
            {
                if (CurrentWord.WordName == SecondWord)
                {
                   
                    curentButton = true;
                        
                   ButtonBackground2 = Brushes.Green;                                        
                    await Task.Delay(1000);
                    ButtonBackground2 = Brushes.Gray;
                    CurentAnswer++;
                }
                else
                {                 
                     ButtonBackground2 = Brushes.Red;             
                     await Task.Delay(1000);                   
                     ButtonBackground2 = Brushes.Gray;
                     IncurentAnswer++;
                 
                 
                }
            }
            else if (selectedWord.ToString() == "Third button")
            {
                if (CurrentWord.WordName == ThirdWord)
                {
                   
                    curentButton = true;
                   
                   ButtonBackground3 = Brushes.Green;               
                    await Task.Delay(1000);
                    ButtonBackground3 = Brushes.Gray;                   
                    CurentAnswer++;
                }
                else
                {
                    ButtonBackground3 = Brushes.Red;
                    await Task.Delay(1000);
                    ButtonBackground3 = Brushes.Gray;
                    IncurentAnswer++;
                  
                   
                }
            }
            else if (selectedWord.ToString() == "Four button")
            {
                if (CurrentWord.WordName == FourWord)
                {
                   
                    curentButton = true;
                 
                   ButtonBackground4 = Brushes.Green;
                    await Task.Delay(1000);
                    ButtonBackground4 = Brushes.Gray;
                    CurentAnswer++;
                }
                else
                {
                    ButtonBackground4 = Brushes.Red;
                    await Task.Delay(1000);
                    ButtonBackground4 = Brushes.Gray;
                    IncurentAnswer++;
                   
                    
                }
            }


            if (curentButton == false)
            {
                switch (_correctButtonIndex)
                {
                    case 1:
                        ButtonBackground1 = Brushes.Green;
                        await Task.Delay(1000);
                        ButtonBackground1 = Brushes.Gray;
                        break;
                    case 2:
                        ButtonBackground2 = Brushes.Green;
                        await Task.Delay(1000);
                        ButtonBackground2 = Brushes.Gray;
                        break;
                    case 3:
                        ButtonBackground3 = Brushes.Green;
                        await Task.Delay(1000);
                        ButtonBackground3 = Brushes.Gray;
                        break;
                    case 4:
                        ButtonBackground4 = Brushes.Green;
                        await Task.Delay(1000);
                        ButtonBackground4 = Brushes.Gray;
                        break;
                    default:

                        break;
                }
            }                  
            UpdateWords();
        }



        //private async Task AnswerSelectedCommandAsyn(object selectedWord)
        //{
        //    if (selectedWord.ToString() == "First button")
        //    {
        //        if (CurrentWord.WordName == FirstWord)
        //        {
        //            lock (showMessageLock)
        //            {
        //                ShowMessage = "Вірно !";
        //                OnPropertyChanged("ShowMessage");
        //            }

        //            await Task.Delay(1000);

        //            lock (showMessageLock)
        //            {
        //                ShowMessage = " ";
        //            }
        //            CurentAnswer++;
        //        }
        //        else
        //        {
        //            IncurentAnswer++;
        //        }
        //    }

        //    // Решта коду...
        //}


        //private async Task AnswerSelectedCommandAsync(object selectedWord)
        //{

        //    if (selectedWord.ToString() == "First button")
        //    {
        //        if (CurrentWord.WordName == FirstWord)
        //        {
        //            lock (showMessageLock)
        //            {
        //                ShowMessage = "Вірно !";
        //                OnPropertyChanged("ShowMessage");
        //            }

        //            await Task.Delay(1000);

        //            lock (showMessageLock)
        //            {
        //                ShowMessage = " ";
        //            }
        //            CurentAnswer++;

        //        }
        //        else
        //        {
        //            lock (showMessageLock)
        //            {
        //                ShowMessage = "Не вірно !";
        //                OnPropertyChanged("ShowMessage");
        //            }

        //            await Task.Delay(1000);

        //            lock (showMessageLock)
        //            {
        //                ShowMessage = " ";
        //            }
        //            IncurentAnswer++;

        //        }
        //        return;
        //    }

        //    if (selectedWord.ToString() == "Second button")
        //    {
        //        if (CurrentWord.WordName == SecondWord)

        //        {
        //            lock (showMessageLock)
        //            {
        //                ShowMessage = "Вірно !";
        //                OnPropertyChanged("ShowMessage");
        //            }

        //            await Task.Delay(1000);

        //            lock (showMessageLock)
        //            {
        //                ShowMessage = " ";
        //            }
        //            CurentAnswer++;
        //        }
        //        else
        //        {
        //            lock (showMessageLock)
        //            {
        //                ShowMessage = "Не вірно !";
        //                OnPropertyChanged("ShowMessage");
        //            }

        //            await Task.Delay(1000);

        //            lock (showMessageLock)
        //            {
        //                ShowMessage = " ";
        //            }
        //            IncurentAnswer++;
        //        }
        //        return;
        //    }

        //    if (selectedWord.ToString() == "Third button")
        //    {

        //        if (CurrentWord.WordName == ThirdWord)

        //        {
        //            lock (showMessageLock)
        //            {
        //                ShowMessage = "Вірно !";
        //                OnPropertyChanged("ShowMessage");
        //            }

        //            await Task.Delay(1000);

        //            lock (showMessageLock)
        //            {
        //                ShowMessage = " ";
        //            }
        //            CurentAnswer++;
        //        }
        //        else
        //        {
        //            lock (showMessageLock)
        //            {
        //                ShowMessage = "Не вірно !";
        //                OnPropertyChanged("ShowMessage");
        //            }

        //            await Task.Delay(1000);

        //            lock (showMessageLock)
        //            {
        //                ShowMessage = " ";
        //            }
        //            IncurentAnswer++;

        //        }
        //        return;
        //    }

        //    if (selectedWord.ToString() == " Four button")
        //    {

        //        if (CurrentWord.WordName == FourWord)

        //        {
        //            lock (showMessageLock)
        //            {
        //                ShowMessage = "Вірно !";
        //                OnPropertyChanged("ShowMessage");
        //            }

        //            await Task.Delay(1000);

        //            lock (showMessageLock)
        //            {
        //                ShowMessage = " ";
        //            }
        //            CurentAnswer++;
        //        }
        //        else
        //        {
        //            lock (showMessageLock)
        //            {
        //                ShowMessage = "Не вірно !";
        //                OnPropertyChanged("ShowMessage");
        //            }

        //            await Task.Delay(1000);

        //            lock (showMessageLock)
        //            {
        //                ShowMessage = " ";
        //            }
        //            IncurentAnswer++;
        //        }
        //        return;
        //    }
        //    UpdateWords();
        //}

        public LearnNewWordsViewModel(LearnNewWordsModel model)
        {
            _model = model;
            UpdateWords();
        }

        private void UpdateWords()
        {
           
            var random = new Random();
            var words = _model.GetWordsForLearning();
           CurrentWord = words[random.Next(words.Count)];
          CurrentWordTranslation=CurrentWord.Translation;           
            int i = 0; 
            foreach (var word in words)
            {
                switch (i++)
                {
                    case 0:
                        FirstWord = word.WordName;
                        break;

                    case 1:
                        SecondWord = word.WordName;
                        break;

                    case 2:
                        ThirdWord = word.WordName;
                        break;

                    case 3:
                        FourWord = word.WordName;
                        break;
                }
            }
        }

       

        public string ShowMessage
        {
            get {
                return _showMessage;                               
            }

            set
            {
                _showMessage = value;
                OnPropertyChanged();
            }

        }


        public int CurentAnswer
        { get { return _curentAnswer; }
        
             set  
             {
                _curentAnswer =value;
                OnPropertyChanged();
             } 
            
        }

        public int IncurentAnswer
        {
            get { return _incurentAnswer; }

            set
            {
                _incurentAnswer = value;
                OnPropertyChanged();
            }

        }
        public string CurrentWordTranslation
        {
            get { return _currentWordTranslation; }

            set
            {
                _currentWordTranslation = value;
                OnPropertyChanged();
            }
        }

        public Word CurrentWord
        {
            get { return _currentWord; }

            set
            {
                _currentWord = value;
                OnPropertyChanged();
            }
        }

        public string FirstWord
        {
            get { return _firstWord; }

            set
            {
                _firstWord = value;
                OnPropertyChanged();
            }
        }

        public string SecondWord
        {
            get { return _secondWord; }

            set
            {
                _secondWord = value;
                OnPropertyChanged();
            }
        }

        public string ThirdWord
        {
            get { return _thirdWord; }

            set
            {
                _thirdWord = value;
                OnPropertyChanged();
            }
        }

        public string FourWord

        {
            get { return _fourWord; }

            set
            {
                _fourWord = value;
                OnPropertyChanged();
            }
        }
    }
}