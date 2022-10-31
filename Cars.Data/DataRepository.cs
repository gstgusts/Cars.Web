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
        private readonly ApplicationDbContext _context;

        public DataRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Owner Create(Owner data)
        {
            _context.Add(data);
            _context.SaveChanges();

            return data;
        }

        public IEnumerable<Owner> GetOwners(string query)
        {
            return _context.Owners.Where(o => o.Name.ToLower().Contains(query.ToLower())
            || o.Surname.ToLower().Contains(query.ToLower())).ToArray();
        }
    }
}
