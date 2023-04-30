﻿using LearnAndGrow.Commands;
using LearnAndGrow.Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace LearnAndGrow.ViewModel
{
    internal class LearnAndGrowViewModel : INotifyPropertyChanged
    {
        private string _firstWord;
        private string _secondWord;
        private string _thirdWord;
        private string _fourWord;
        private readonly LearnAndGrowModel _model;
        private string _currentWord;

        private RelayCommand _selectWordCommand;

        public ICommand SelectWordCommand
        {
            get
            {
                if (_selectWordCommand == null)
                {
                    _selectWordCommand = new RelayCommand(param => AnswerSelectedCommand());
                }
                return _selectWordCommand;
            }
        }

        private void AnswerSelectedCommand()
        {
            UpdateWords();
        }

        public LearnAndGrowViewModel(LearnAndGrowModel model)
        {
            _model = model;
            UpdateWords();
        }

        private void UpdateWords()
        {     
            var random = new Random();
            var words = _model.GetWordsForLearning();
            CurrentWord = words[random.Next(words.Count)].WordInEnglish;

            int i = 0;
            foreach (var word in words)
            {
                switch (i++)
                {
                    case 0:
                        FirstWord = word.WordInUkrainian;
                        break;

                    case 1:
                        SecondWord = word.WordInUkrainian;
                        break;

                    case 2:
                        ThirdWord = word.WordInUkrainian;
                        break;

                    case 3:
                        FourWord = word.WordInUkrainian;
                        break;
                }
            }
        }

        public string CurrentWord
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}