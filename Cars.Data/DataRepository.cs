using Cars.Data.Interfaces;
using Cars.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Data
{
    public class DataRepository : IDataRepository
    {
        public IEnumerable<Owner> GetOwners(string query)
        {
            var options = new DbContextOptions<ApplicationDbContext>();


            using (var context = new ApplicationDbContext(options))
            {
                return context.Owners.Where(o => o.Name.Contains(query, StringComparison.InvariantCultureIgnoreCase)
                || o.Surname.Contains(query, StringComparison.InvariantCultureIgnoreCase)).ToArray();
            }
        }
    }
}
