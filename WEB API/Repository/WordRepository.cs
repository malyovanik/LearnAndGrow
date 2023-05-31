using Contracts.WEB.Interfaces;
using Entities.WEB;
using Entities.WEB.Models;
using Repository.WEB.Base;

namespace Repository.WEB
{
    public class WordRepository : RepositoryBase<WordModel>, IWordRepository
    {
        public WordRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void AddWord(WordModel word)
        {
            Create(word);
        }

        public void DeleteWord(WordModel word)
        {
            Delete(word);
        }

        public IEnumerable<WordModel> GetAllWords() => FindAll().OrderBy(w => w.WordId).ToList();

        public WordModel GetWordById(int id) => FindByCondition(w => w.WordId == id).FirstOrDefault();

        public WordModel GetWordByName(string wordName)
        {
            return FindByCondition(w => string.Equals(w.WordName, wordName)).FirstOrDefault();
        }

        public void UpdateWord(WordModel word)
        {
            Update(word);
        }
    }
}