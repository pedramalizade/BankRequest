namespace BankRequest.Domain.Core.Contracts.AppService
{
    public interface IShebaRequestAppService
    {
        /// <summary>افزودن درخواست جدید</summary>
        Task<object> CreateRequestAsync(ShebaRequestDto dto, CancellationToken cancellationToken);
        /// <summary>دریافت همه درخواست‌ها</summary>
        Task<List<ShebaRequest>> GetAllAsync(CancellationToken cancellationToken);
        /// <summary>تغییر وضعیت درخواست</summary>
        Task<object> UpdateStatusAsync(int id, RequestStatus status, string note, CancellationToken cancellationToken);
    }
}
