using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEBEEJ.Data.Entities
{
    public enum StatusType
    {
        Pending = 0,
        Paid = 1,
        Shipped = 2,
        Completed = 3,
        Refunded = 4,
        Cancelled = 5,
        Declined = 6,
        Disputed = 7
    }
}
