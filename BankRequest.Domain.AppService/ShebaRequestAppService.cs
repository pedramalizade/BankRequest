namespace BankRequest.Domain.AppService
{
    public class ShebaRequestAppService : IShebaRequestAppService
    {
        private readonly IShebaRequestService _service;

        public ShebaRequestAppService(IShebaRequestService service)
        {
            _service = service;
        }

        /// <summary>ایجاد درخواست شبا</summary>
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

        /// <summary>دریافت همه درخواست‌ها</summary>
        public async Task<List<ShebaRequest>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync(cancellationToken);
        }

        /// <summary>تغییر وضعیت درخواست</summary>
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
