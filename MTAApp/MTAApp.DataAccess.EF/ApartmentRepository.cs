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
    public class ApartmentRepository : BaseRepository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(DbContext dbContext) : base(dbContext)
        {
        }
        public Apartment GetApartmentByApNr(int apNr)
        {
            return dbContext.Set<Apartment>().Where(c => c.ApNumber.Equals(apNr))
                                            .FirstOrDefault();
        }
        public Apartment GetApartmentByTenantName(string tenantName)
        {
            return dbContext.Set<Apartment>().Where(c => c.TenantName.Equals(tenantName))
                                            .FirstOrDefault();
        }
    }
}
