namespace BankRequest.Domain.Core.Enums
{
    public enum RequestStatus
    {
        /// <summary>
        /// در انتظار
        /// </summary>
        Pending,

        /// <summary>
        /// تایید شده
        /// </summary>
        Approved,

        /// <summary>
        /// رد شده
        /// </summary>
        Rejected
    }
}
