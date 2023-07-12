using System.Collections.Generic;

namespace LearnAndGrow.Model.Childs
{
    public class LearnNewWordsModel
    {
        private Vocabulary _vocabulary { get; set; } = new Vocabulary();
        public LearnNewWordsModel()
        {
        }

        public List<Word> GetWordsForLearning()
        {
            return _vocabulary.GetWordsForLearning();
        }
    }
}