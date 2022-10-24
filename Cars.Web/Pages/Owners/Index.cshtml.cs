using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cars.Data;
using Cars.Data.Models;

namespace Cars.Web.Pages.Owners
{
    public class IndexModel : PageModel
    {
        private readonly Cars.Data.ApplicationDbContext _context;

        public IndexModel(Cars.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Owner> Owner { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Owners != null)
            {
                Owner = await _context.Owners.ToListAsync();
            }
        }
    }
}
