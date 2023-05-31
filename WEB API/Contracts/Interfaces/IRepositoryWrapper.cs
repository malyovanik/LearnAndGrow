namespace Contracts.WEB.Interfaces
{
    public interface IRepositoryWrapper
    {
        IWordRepository Word { get; }

        void Save();
    }
}