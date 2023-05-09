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
    public class ContractRepository : BaseRepository<Contract>, IContractRepository
    {
        public ContractRepository(DbContext dbContext) : base(dbContext){ }

        public Contract GetContractByType(string type)
        {
            return dbContext.Set<Contract>().Where(c => c.Type.Equals(type))
                                            .FirstOrDefault();
        }
    }
}
