namespace BankRequest.Domain.Core.Entites
{
    public class ShebaRequest
    {
        /// <summary>شناسه</summary>
        public int Id { get; set; }
        /// <summary>مبلغ</summary>
        public long Price { get; set; }
        /// <summary>شماره شبای مبدأ</summary>
        [Required]
        [StringLength(24, MinimumLength = 24, ErrorMessage = "Sheba number must be 24 characters.")]
        [RegularExpression(@"^IR\d{24}$", ErrorMessage = "Invalid Sheba number format.")]
        public string FromShebaNumber { get; set; }
        /// <summary>شماره شبای مقصد</summary>
        [Required]
        [StringLength(24, MinimumLength = 24, ErrorMessage = "Sheba number must be 24 characters.")]
        [RegularExpression(@"^IR\d{24}$", ErrorMessage = "Invalid Sheba number format.")]
        public string ToShebaNumber { get; set; }
        /// <summary>توضیحات</summary>
        public string Note { get; set; }
        /// <summary>وضعیت درخواست</summary>
        public RequestStatus Status { get; set; } = RequestStatus.Pending;
        /// <summary>تاریخ ایجاد</summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
