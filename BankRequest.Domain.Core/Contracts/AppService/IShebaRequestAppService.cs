using BankRequest.Domain.Core.DTOs;
using BankRequest.Domain.Core.Entites;
using BankRequest.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankRequest.Domain.Core.Contracts.AppService
{
    public interface IShebaRequestAppService
    {
        Task<object> CreateRequestAsync(ShebaRequestDto dto, CancellationToken cancellationToken);
        Task<List<ShebaRequest>> GetAllAsync(CancellationToken cancellationToken);
        Task<object> UpdateStatusAsync(int id, RequestStatus status, string note, CancellationToken cancellationToken);
    }
}
