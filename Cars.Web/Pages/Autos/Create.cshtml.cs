using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cars.Data;
using Cars.Data.Models;

namespace Cars.Web.Pages.Autos
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cars.Add(Car);

            if(Car.OwnerId.HasValue)
            {
                var owner = _context.Owners.FirstOrDefault(o => o.Id == Car.OwnerId);

                var history = new CarHistory
                {
                    Id = 0,
                    Car = Car,
                    DateFrom = DateTime.Now,
                    Owner = owner
                };

                _context.CarsHistory.Add(history);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
