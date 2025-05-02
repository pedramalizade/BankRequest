using BankRequest.Domain.Core.DTOs;
using BankRequest.Domain.Core.Entites;
using BankRequest.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
