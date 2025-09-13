namespace BankRequest.Domain.Core.Contracts.Repository
{
    public interface IShebaRequestRepository
    {
        Task AddAsync(ShebaRequest request, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
        Task<Account> GetAccountByShebaNumberAsync(string shebaNumber, CancellationToken cancellationToken);
        Task<List<ShebaRequest>> GetAllAsync(CancellationToken cancellationToken);
        Task<ShebaRequest?> UpdateStatusAsync(int id, RequestStatus status, string note, CancellationToken cancellationToken);
    }
}
