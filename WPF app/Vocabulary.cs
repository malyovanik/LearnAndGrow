using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Markup;

namespace LearnAndGrow
{
    public class Word
    {
        public Word(string wordName, string translation) 
        {
            WordName = wordName;
            Translation = translation;
        }
        public int WordId { get; set; }
        public string WordName { get; set; }
        public string Translation { get; set; }
    }

    internal class Vocabulary
    {
        public List<Word> Words { get; private set; } = new List<Word>();

        public Vocabulary()
        {
            Initialize();
        }

        ~Vocabulary()
        {
            SaveWords();
        }


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
            Words.Add(word);

            using (var client = new HttpClient())
            {
               //client.BaseAddress = new Uri("http://localhost:8090/api/");

                var jsonData = JsonConvert.SerializeObject(word);
                var stringContent = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");

                //HTTP GET
                var responseTask = client.PostAsync("http://localhost:8090/api/words", stringContent);
                responseTask.Wait();

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
            var words = new List<Word>();
            var random = new Random();
            for (int i = 0; i < 4; i++)
            {
                var randWord = Words[random.Next(Words.Count)];
                if (!words.Any(w => w.Translation == randWord.Translation))
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


        private void SaveWords()
        {
            throw new NotImplementedException();
        }
    }
}