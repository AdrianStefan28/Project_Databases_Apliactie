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
    public class PollRepository : BaseRepository<Poll>, IPollRepository
    {
        public PollRepository(DbContext dbContext) : base(dbContext)
        {
        }
        public Poll GetPollBySubject(string subject)
        {
            return dbContext.Set<Poll>().Where(c => c.Subject.Equals(subject))
                                            .FirstOrDefault();
        }
    }
}
