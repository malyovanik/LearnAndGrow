using Entities.WEB.Models;

namespace Contracts.WEB.Interfaces
{
    public interface IWordRepository : IRepositoryBase<WordModel>
    {
        IEnumerable<WordModel> GetAllWords();

        WordModel GetWordByName(string wordName);

        WordModel GetWordById(int id);

        void AddWord(WordModel word);

        void UpdateWord(WordModel word);

        void DeleteWord(WordModel id);
    }
}