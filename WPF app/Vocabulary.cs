using LearnAndGrow.Utilities;
using LearnAndGrow.View.Childs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Markup;

namespace LearnAndGrow
{
    public class Word
    {
        public Word()
        {
        }

        public Word(string wordName, string translation) 
        {
            WordName = wordName;
            Translation = translation;
            LearnAnswers = 0;
        }
        public int LearnAnswers  { get; set; }   
        public int WordId  { get; set; }
        public string WordName { get; set; }
        public string Translation { get; set; }
    }

    public class Vocabulary
    {
        public List<Word> Words { get; private set; } = new List<Word>();
        int resaultRightAnsver = 0;
        public Vocabulary()
        {
            Initialize();
        }

        //~Vocabulary()
        //{
        //    SaveWords();
        //}
        //public void RightAnswersCont()
        //{
        //    foreach (Word word in Words) 
        //    {
        //        word.WordId++;
        //    }
        //}



        private void Initialize()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8090/api/");
                //HTTP GET
                var responseTask = client.GetAsync("words");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<Word[]>();
                    readTask.Wait();

                    Words = readTask.Result.ToList();
                }
            }
        }

        public void AddWord(Word word)
        {
            if (word.WordName == null || (word.Translation == null)) 
            {
                return;
            }

            foreach (var wordss in Words)
            {
                if ((word.WordName.ToLower() == wordss.WordName.ToLower()) && (word.Translation.ToLower() == wordss.Translation.ToLower()))
                {
                    MessageBox.Show(" Це слово вже існує !!!");
                    return;
                }
            }
            Words.Add(word);

            using (var client = new HttpClient())
            {
               //client.BaseAddress = new Uri("http://localhost:8090/api/");

                var jsonData = JsonConvert.SerializeObject(word);
                var stringContent = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");

                //HTTP GET
                var responseTask = client.PostAsync("http://localhost:8090/api/words", stringContent);
                responseTask.Wait();

                MessageBox.Show(" Слово успішно добавлено !");
                

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    //var readTask = result.Content.ReadAsAsync<Word[]>();
                    //readTask.Wait();

                    //Words = readTask.Result.ToList();
                }
            }

        }

        public List<Word> GetWordsForLearning()
        {
            //var words = new List<Word>();
            //var random = new Random();
            //for (int i = 0; i < 4; i++)
            //{
            //    var randWord = Words[random.Next(Words.Count)];
            //    if (!words.Any(w => w.Translation == randWord.Translation))
            //    {
            //        words.Add(randWord);
            //    }

            //    if (words.Count == 4)
            //    {
            //        break;
            //    }
            //}

            var words = new List<Word>();
            var random = new Random();

            while (words.Count < 4)
            {
                var randWord = Words[random.Next(Words.Count)];
                if (!words.Any(w => w.Translation == randWord.Translation))
                {
                    words.Add(randWord);
                }
            }

            return words;
        }


       //public void RightAnswersContResault()
       // {
            
       //     int resaultRightAnsver = 0;
       //     foreach(var word in Words) 
       //     {
       //         if (word.WordId >= 2)
       //         {
       //             resaultRightAnsver++;  
       //         }
               
       //     }

       // }
        public int ShowCount()
        {
            int count = Words.Count;
            return count;
        }

        public int ShowCountRightAnswer()
        {
            int resault = resaultRightAnsver;        
            return resault;
        }

        public int ShowCountLeftAnswer()
        {
            int a =Words.Count;
            int b = resaultRightAnsver;
            int resault = a - b;

            return resault;
        }
    }
}