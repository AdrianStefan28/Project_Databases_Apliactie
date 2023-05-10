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
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(DbContext dbContext) : base(dbContext) { }

        public Contact GetContactByName(string fname, string lname)
        {
            return dbContext.Set<Contact>().Where(c => c.FirstName.Equals(fname) && c.LastName.Equals(lname))
                                            .FirstOrDefault();
        }
    }
}
