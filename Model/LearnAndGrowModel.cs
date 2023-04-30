using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnAndGrow.Model
{
    internal class LearnAndGrowModel
    {
        public LearnAndGrowModel()
        {
            AllWords = new List<Word>()
            {
                new Word(1, "Job", "Робота"),
                new Word(2, "Dog", "Собака"),
                new Word(3, "Cat", "Кіт"),
                new Word(4, "Cup", "Чашка"),
                new Word(5, "Laptop", "Ноутбук"),
                new Word(6, "Mouse", "Миша"),
                new Word(7, "Keyboard", "Клавіатура"),
                new Word(8, "Wath", "Дивитись"),
                new Word(9, "Clock", "Годинник"),
                new Word(10, "Sunset", "Захід сонця"),
                new Word(11, "Sunrice", "Схід Сонця"),
                new Word(12, "Night", "Ніч"),
                new Word(13, "Day", "День"),
                new Word(14, "Week", "Тиждень"),
                new Word(15, "Book", "Книга")
            };
        }

        public List<Word> AllWords { get; set; }

        public List<Word> GetWordsForLearning()
        {
            var words = new List<Word>();
            var random = new Random();
            for (int i = 0; i < 4; i++)
            {
                var randWord = AllWords[random.Next(AllWords.Count)];
                if (!words.Any(w => w.NumberInVocabulary == randWord.NumberInVocabulary))
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
    }
}