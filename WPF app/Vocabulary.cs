using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnAndGrow
{
    internal class Vocabulary
    {
        public static List<Word> Words { get; private set; } = new List<Word>();

        public Vocabulary()
        {
            LoadWords();
            Initialize();
        }

        ~Vocabulary()
        {
            SaveWords();
        }

        private void Initialize()
        {
            Words = new List<Word>()
            {
                new Word("Job", "Робота"),
                new Word("Dog", "Собака"),
                new Word("Cat", "Кіт"),
                new Word("Cup", "Чашка"),
                new Word("Laptop", "Ноутбук"),
                new Word("Mouse", "Миша"),
                new Word("Keyboard", "Клавіатура"),
                new Word("Wath", "Дивитись"),
                new Word("Clock", "Годинник"),
                new Word("Sunset", "Захід сонця"),
                new Word("Sunrice", "Схід Сонця"),
                new Word("Night", "Ніч"),
                new Word("Day", "День"),
                new Word("Week", "Тиждень"),
                new Word("Book", "Книга")
            };
        }

        public static void AddWord(Word word)
        {
            Words.Add(word);
        }

        public static List<Word> GetWordsForLearning()
        {
            var words = new List<Word>();
            var random = new Random();
            for (int i = 0; i < 4; i++)
            {
                var randWord = Words[random.Next(Words.Count)];
                if (!words.Any(w => w.WordInForeignLanguage == randWord.WordInForeignLanguage))
                {
                    words.Add(randWord);
                }

                if (words.Count == 4)
                {
                    break;
                }
            }

            return words;
        }

        private void LoadWords()
        {
            throw new NotImplementedException();
        }

        private void SaveWords()
        {
            throw new NotImplementedException();
        }
    }
}