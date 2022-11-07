using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cars.Data;
using Cars.Data.Models;

namespace Cars.Web.Pages.Autos
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public string[] CarEngineTypes = { 
            CarEngineTypeEnum.Petrol.ToString(),
            CarEngineTypeEnum.Diesel.ToString(),
            CarEngineTypeEnum.Electric.ToString()
        };

        public IEnumerable<SelectListItem> AllOwners { get; set; } = new List<SelectListItem>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car =  await _context.Cars.Include(o => o.Owner).FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            Car = car;

            var allOwners = new List<SelectListItem>
            {
                new SelectListItem("-","")
            };

            allOwners.AddRange(_context.Owners.Select(o => new SelectListItem(o.Surname+" "+o.Name, o.Id.ToString())));

            AllOwners = allOwners;

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var carOldData = _context.Cars.FirstOrDefault(c => c.Id == Car.Id);

            if(carOldData.OwnerId.HasValue && Car.OwnerId.HasValue && carOldData.OwnerId != Car.OwnerId)
            {
                var date = DateTime.Now;

                var prevHistoryData = _context.CarsHistory.FirstOrDefault(c => c.Car.Id == Car.Id && c.Owner.Id == carOldData.OwnerId);
                prevHistoryData.DateTo = date;

                _context.SaveChanges();

                var owner = _context.Owners.FirstOrDefault(o => o.Id == Car.OwnerId);

                var newHistoryData = new CarHistory
                {
                    Id = 0,
                    DateFrom = date,
                    CarId = Car.Id,
                    OwnerId = owner.Id
                };

                _context.CarsHistory.Add(newHistoryData);

                _context.SaveChanges();
            }


            //var car = _context.Cars.FirstOrDefault(c => c.Id == Car.Id);

            carOldData.RegistrationPlate = Car.RegistrationPlate;
            carOldData.VinNumber = Car.VinNumber;
            carOldData.Type = Car.Type;
            carOldData.OwnerId = Car.OwnerId;

            //_context.Attach(Car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Car.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CarExists(int id)
        {
          return _context.Cars.Any(e => e.Id == id);
        }
    }
}
