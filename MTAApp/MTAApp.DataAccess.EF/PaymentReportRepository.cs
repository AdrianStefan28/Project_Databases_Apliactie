using Microsoft.EntityFrameworkCore;
using MTAApp.DataAccess.Abstractions;
using MTAApp.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAApp.DataAccess.EF
{
    public class PaymentReportRepository : BaseRepository<PaymentReport>, IPaymentReportRepository
    {
        public PaymentReportRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
