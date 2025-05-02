using BankRequest.Domain.Core.Entites;
using BankRequest.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
