﻿using MTAApp.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAApp.DataAccess.Abstractions
{
    public interface IPollRepository : IBaseRepository<Poll>
    {
        Poll? GetPollBySubject(string subject);
    }
}
