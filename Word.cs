namespace LearnAndGrow
{
    public enum EnumGeneration
    {
        Zero,
        First,
        Second
    }

    public class Word
    {
        public Word(string word, string translation)
        {
            WordInForeignLanguage = word;
            WordInNativeLanguage = translation;
            Generation = EnumGeneration.Zero;
        }

        public EnumGeneration Generation { get; private set; }

        public readonly string WordInForeignLanguage;
        public readonly string WordInNativeLanguage;

        public int CountOfCorrentAnswers { get; private set; }

        public bool CheckAnswer(string answer)
        {
            bool isCorrectAnswer = string.Equals(answer, WordInForeignLanguage);
            if (isCorrectAnswer)
            {
                if (++CountOfCorrentAnswers == 3)
                {
                    UpdateGeneration();
                }
            }

            return isCorrectAnswer;
        }

        private void UpdateGeneration()
        {
            Generation++;
        }
    }
}