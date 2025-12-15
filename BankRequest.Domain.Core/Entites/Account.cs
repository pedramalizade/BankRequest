namespace BankRequest.Domain.Core.Entites
{
    public class Account
    {
        /// <summary>
        /// شناسه
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// شماره شبا
        /// </summary>
        public string ShebaNumber { get; set; }
        /// <summary>
        /// موجودی قابل برداشت
        /// </summary>
        public long AvailableBalance { get; set; }
    }
}
