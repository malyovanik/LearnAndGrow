using Contracts.WEB.Interfaces;
using Entities.WEB;

namespace Repository.WEB.Wrappers
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IWordRepository _word;

        public IWordRepository Word
        {
            get
            {
                if (_word == null)
                {
                    _word = new WordRepository(_repoContext);
                }
                return _word;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}