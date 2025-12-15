namespace BankRequest.EndPoint.WebApi.Controllers
{
    [ApiController]
    [Route("api/sheba")]
    public class ShebaRequestsController : ControllerBase
    {
        private readonly IShebaRequestAppService _appService;

        public ShebaRequestsController(IShebaRequestAppService appService)
        {
            _appService = appService;
        }

        /// <summary>ایجاد درخواست شبا</summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ShebaRequestDto dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  
            }
            var result = await _appService.CreateRequestAsync(dto, cancellationToken);
            return Ok(result);
        }

        /// <summary>دریافت همه درخواست‌ها</summary>
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _appService.GetAllAsync(cancellationToken);
            return Ok(new { requests = result });
        }

        /// <summary>تغییر وضعیت درخواست</summary>
        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] StatusUpdateDto dto, CancellationToken cancellationToken)
        {
            var status = Enum.Parse<RequestStatus>(dto.Status, true);
            var result = await _appService.UpdateStatusAsync(id, status, dto.Note, cancellationToken);
            return Ok(result);
        }
    }
}
