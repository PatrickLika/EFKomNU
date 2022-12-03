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
    public class DetailsModel : PageModel
    {
        private readonly EFKomNU.Data.UnikContext _context;

        public DetailsModel(EFKomNU.Data.UnikContext context)
        {
            _context = context;
        }

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
    }
}
