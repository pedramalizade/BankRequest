using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankRequest.Domain.Core.DTOs
{
    public class ShebaRequestDto
    {
        public long Price { get; set; }
        public string FromShebaNumber { get; set; }
        public string ToShebaNumber { get; set; }
        public string Note { get; set; }
    }
}
