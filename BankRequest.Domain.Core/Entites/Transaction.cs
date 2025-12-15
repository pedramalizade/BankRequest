namespace BankRequest.Domain.Core.Entites
{
    public class Transaction
    {
        /// <summary>شناسه</summary>
        public int Id { get; set; }
        /// <summary>شناسه درخواست</summary>
        public int RequestId { get; set; }
        /// <summary>مبلغ</summary>
        public long Amount { get; set; }
        /// <summary>توضیحات</summary>
        public string Description { get; set; }
        /// <summary>تاریخ ایجاد</summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
