﻿using MTAApp.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAApp.DataAccess.Abstractions
{
    public interface IApartmentRepository : IBaseRepository<Apartment>
    {
        Apartment? GetApartmentByApNr(int apNr);
        Apartment? GetApartmentByTenantName(string tenantName);
    }
   
}
