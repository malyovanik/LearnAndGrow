using System.Collections.Generic;

namespace LearnAndGrow.Model.Childs
{
    public class LearnNewWordsModel
    {
        public List<Word> GetWordsForLearning()
        {
            return Vocabulary.GetWordsForLearning();
        }
    }
}