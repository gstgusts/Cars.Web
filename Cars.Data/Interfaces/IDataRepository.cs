using Cars.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Data.Interfaces
{
    public interface IDataRepository
    {
        IEnumerable<Owner> GetOwners(string query);
    }
}
