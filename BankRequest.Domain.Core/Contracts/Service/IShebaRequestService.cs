namespace BankRequest.Domain.Core.Contracts.Service
{
    public interface IShebaRequestService
    {
        Task<object> CreateRequestAsync(ShebaRequestDto dto, CancellationToken cancellationToken);
        Task<ShebaRequest> CreateAsync(ShebaRequest request, CancellationToken cancellationToken);
        Task<List<ShebaRequest>> GetAllAsync(CancellationToken cancellationToken);
        Task<ShebaRequest?> UpdateStatusAsync(int id, RequestStatus status, string note, CancellationToken cancellationToken);
    }
}
