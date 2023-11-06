namespace Entities.WEB.DataTransferObjects
{
    public class WordDTO
    {
        public int WordId { get; set; }
        public int LearnAnswers { get; set; }

        public string? WordName { get; set; } //TODO: Make readonly.

        public string? Translation { get; set; }
    }
}