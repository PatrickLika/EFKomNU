using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFKomNU.Data;
using EFKomNU.Model;

namespace EFKomNU.Pages.Medarbejder
{
    public class DeleteModel : PageModel
    {
        private readonly EFKomNU.Data.UnikContext _context;

        public DeleteModel(EFKomNU.Data.UnikContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Model.Medarbejder Medarbejder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MedarbejderEntities == null)
            {
                return NotFound();
            }

            var medarbejder = await _context.MedarbejderEntities.FirstOrDefaultAsync(m => m.Id == id);

            if (medarbejder == null)
            {
                return NotFound();
            }
            else 
            {
                Medarbejder = medarbejder;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.MedarbejderEntities == null)
            {
                return NotFound();
            }
            var medarbejder = await _context.MedarbejderEntities.FindAsync(id);

            if (medarbejder != null)
            {
                Medarbejder = medarbejder;
                _context.MedarbejderEntities.Remove(Medarbejder);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
