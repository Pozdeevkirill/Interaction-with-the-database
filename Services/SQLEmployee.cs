using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SQLEmployee
    {
        private CRMDBContext _context;

        public SQLEmployee(CRMDBContext context)
        {
            _context = context;
        }
    }
}
