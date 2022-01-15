namespace Service.Interfaces;

public interface IUnitOfWork
{
    IUrlRepository Url { get; }
    Task<int> SaveAsync();
}