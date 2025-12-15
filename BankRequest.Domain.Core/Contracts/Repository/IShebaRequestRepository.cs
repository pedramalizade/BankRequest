namespace BankRequest.Domain.Core.Contracts.Repository
{
    public interface IShebaRequestRepository
    {
        /// <summary>افزودن درخواست جدید</summary>
        Task AddAsync(ShebaRequest request, CancellationToken cancellationToken);
        /// <summary>ذخیره تغییرات</summary>
        Task SaveChangesAsync(CancellationToken cancellationToken);
        /// <summary>دریافت حساب با شماره شبا</summary>
        Task<Account> GetAccountByShebaNumberAsync(string shebaNumber, CancellationToken cancellationToken);
        /// <summary>دریافت همه درخواست‌ها</summary>
        Task<List<ShebaRequest>> GetAllAsync(CancellationToken cancellationToken);
        /// <summary>تغییر وضعیت درخواست</summary>
        Task<ShebaRequest?> UpdateStatusAsync(int id, RequestStatus status, string note, CancellationToken cancellationToken);
    }
}
