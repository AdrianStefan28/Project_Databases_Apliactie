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
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext dbContext) : base(dbContext) { }
        public Employee GetEmployeeByName(string fname, string lname)
        {
            return dbContext.Set<Employee>().Where(c => c.FirstName.Equals(fname) &&  c.LastName.Equals(lname))
                                            .FirstOrDefault();
        }
        public Employee GetEmployeeByType(string type)
        {
            return dbContext.Set<Employee>().Where(c => c.Type.Equals(type))
                                            .FirstOrDefault();
        }
    }
}
