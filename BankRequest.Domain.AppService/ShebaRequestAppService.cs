using BankRequest.Domain.Core.Contracts.AppService;
using BankRequest.Domain.Core.Contracts.Service;
using BankRequest.Domain.Core.DTOs;
using BankRequest.Domain.Core.Entites;
using BankRequest.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankRequest.Domain.AppService
{
    public class ShebaRequestAppService : IShebaRequestAppService
    {
        private readonly IShebaRequestService _service;

        public ShebaRequestAppService(IShebaRequestService service)
        {
            _service = service;
        }

        public async Task<object> CreateRequestAsync(ShebaRequestDto dto, CancellationToken cancellationToken)
        {
            try
            {
                var request = new ShebaRequest
                {
                    Price = dto.Price,
                    FromShebaNumber = dto.FromShebaNumber,
                    ToShebaNumber = dto.ToShebaNumber,
                    Note = dto.Note
                };

                var saved = await _service.CreateAsync(request, cancellationToken);
                return new
                {
                    message = "درخواست با موفقیت ذخیره شد و در وضعیت در انتظار قرار دارد",
                    request = saved
                };
            }
            catch (Exception ex)
            {
                return new { message = ex.Message, code = "400" };
            }
        }

        public async Task<List<ShebaRequest>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync(cancellationToken);
        }

        public async Task<object> UpdateStatusAsync(int id, RequestStatus status, string note, CancellationToken cancellationToken)
        {
            var updated = await _service.UpdateStatusAsync(id, status, note, cancellationToken);
            if (updated == null)
            {
                return new { message = "درخواست با شناسه مورد نظر یافت نشد", code = "404" };
            }

            return new
            {
                message = $"درخواست به وضعیت {status} تغییر کرد!",
                request = updated
            };
        }
    }
}
