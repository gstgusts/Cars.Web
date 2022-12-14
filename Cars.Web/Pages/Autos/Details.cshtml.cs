using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cars.Data;
using Cars.Data.Models;

namespace Cars.Web.Pages.Autos
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

      public Car Car { get; set; }

        public IEnumerable<CarHistory> CarHistory { get; set; } = new List<CarHistory>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            else 
            {
                Car = car;
                CarHistory = _context.CarsHistory
                    .Include(m => m.Car)
                    .Include(o => o.Owner)
                    .Where(c => c.CarId == car.Id);
            }
            return Page();
        }
    }
}
