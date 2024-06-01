using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fina.Core.Requests.Transactions
{
    public class GetTransactionByPeriodRequest : PagedRequest
    {
        public DateTime? StartedDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}