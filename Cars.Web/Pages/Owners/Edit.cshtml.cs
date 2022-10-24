﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cars.Data;
using Cars.Data.Models;

namespace Cars.Web.Pages.Owners
{
    public class EditModel : PageModel
    {
        private readonly Cars.Data.ApplicationDbContext _context;

        public EditModel(Cars.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Owner Owner { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Owners == null)
            {
                return NotFound();
            }

            var owner =  await _context.Owners.FirstOrDefaultAsync(m => m.Id == id);
            if (owner == null)
            {
                return NotFound();
            }
            Owner = owner;
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

            _context.Attach(Owner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerExists(Owner.Id))
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

        private bool OwnerExists(int id)
        {
          return _context.Owners.Any(e => e.Id == id);
        }
    }
}
