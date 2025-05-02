using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankRequest.Domain.Core.Entites
{
    public class Account
    {
        public int Id { get; set; }
        public string ShebaNumber { get; set; }
        public long AvailableBalance { get; set; }
    }
}
