namespace BankRequest.Domain.Core.Contracts.AppService
{
    public interface IShebaRequestAppService
    {
        Task<object> CreateRequestAsync(ShebaRequestDto dto, CancellationToken cancellationToken);
        Task<List<ShebaRequest>> GetAllAsync(CancellationToken cancellationToken);
        Task<object> UpdateStatusAsync(int id, RequestStatus status, string note, CancellationToken cancellationToken);
    }
}
