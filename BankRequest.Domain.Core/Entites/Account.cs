namespace BankRequest.Domain.Core.Entites
{
    public class Account
    {
        public int Id { get; set; }
        public string ShebaNumber { get; set; }
        public long AvailableBalance { get; set; }
    }
}
