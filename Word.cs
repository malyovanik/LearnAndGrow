namespace LearnAndGrow
{
    public class Word
    {
        public Word(int numberInVocabulary, string wordInEnglish, string wordInUkrainian)
        {
            NumberInVocabulary = numberInVocabulary;
            WordInEnglish = wordInEnglish;
            WordInUkrainian = wordInUkrainian;
        }

        public readonly int NumberInVocabulary;
        public readonly string WordInEnglish;
        public readonly string WordInUkrainian;
    }
}