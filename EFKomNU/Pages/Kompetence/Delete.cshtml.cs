using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFKomNU.Data;
using EFKomNU.Model;

namespace EFKomNU.Pages.Kompetence
{
    public class DeleteModel : PageModel
    {
        private readonly EFKomNU.Data.UnikContext _context;

        public DeleteModel(EFKomNU.Data.UnikContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Model.Kompetence Kompetence { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.KompetenceEntities == null)
            {
                return NotFound();
            }

            var kompetence = await _context.KompetenceEntities.FirstOrDefaultAsync(m => m.Id == id);

            if (kompetence == null)
            {
                return NotFound();
            }
            else 
            {
                Kompetence = kompetence;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.KompetenceEntities == null)
            {
                return NotFound();
            }
            var kompetence = await _context.KompetenceEntities.FindAsync(id);

            if (kompetence != null)
            {
                Kompetence = kompetence;
                _context.KompetenceEntities.Remove(Kompetence);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
