using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFKomNU.Data;
using EFKomNU.Model;

namespace EFKomNU.Pages.Kompetence
{
    public class EditModel : PageModel
    {
        private readonly EFKomNU.Data.UnikContext _context;

        public EditModel(EFKomNU.Data.UnikContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Model.Kompetence Kompetence { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.KompetenceEntities == null)
            {
                return NotFound();
            }

            var kompetence =  await _context.KompetenceEntities.FirstOrDefaultAsync(m => m.Id == id);
            if (kompetence == null)
            {
                return NotFound();
            }
            Kompetence = kompetence;
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

            _context.Attach(Kompetence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KompetenceExists(Kompetence.Id))
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

        private bool KompetenceExists(int id)
        {
          return _context.KompetenceEntities.Any(e => e.Id == id);
        }
    }
}
