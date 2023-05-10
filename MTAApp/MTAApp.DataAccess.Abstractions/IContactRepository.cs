using MTAApp.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAApp.DataAccess.Abstractions
{
    public interface IContactRepository : IBaseRepository<Contact>
    {
        Contact? GetContactByName(string fname, string lname);
    }
}
