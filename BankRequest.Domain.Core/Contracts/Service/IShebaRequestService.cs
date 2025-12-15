namespace BankRequest.Domain.Core.Contracts.Service
{
    public interface IShebaRequestService
    {
        /// <summary>ایجاد درخواست از DTO</summary>
        Task<object> CreateRequestAsync(ShebaRequestDto dto, CancellationToken cancellationToken);
        /// <summary>ایجاد درخواست</summary>
        Task<ShebaRequest> CreateAsync(ShebaRequest request, CancellationToken cancellationToken);
        /// <summary>دریافت همه درخواست‌ها</summary>
        Task<List<ShebaRequest>> GetAllAsync(CancellationToken cancellationToken);
        /// <summary>تغییر وضعیت درخواست</summary>
        Task<ShebaRequest?> UpdateStatusAsync(int id, RequestStatus status, string note, CancellationToken cancellationToken);
    }
}
