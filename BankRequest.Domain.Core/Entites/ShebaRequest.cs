namespace BankRequest.Domain.Core.Entites
{
    public class ShebaRequest
    {
        public int Id { get; set; }
        public long Price { get; set; }

        [Required]
        [StringLength(24, MinimumLength = 24, ErrorMessage = "Sheba number must be 24 characters.")]
        [RegularExpression(@"^IR\d{24}$", ErrorMessage = "Invalid Sheba number format.")]
        public string FromShebaNumber { get; set; }

        [Required]
        [StringLength(24, MinimumLength = 24, ErrorMessage = "Sheba number must be 24 characters.")]
        [RegularExpression(@"^IR\d{24}$", ErrorMessage = "Invalid Sheba number format.")]
        public string ToShebaNumber { get; set; }
        public string Note { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
