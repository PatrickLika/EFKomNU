using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EFKomNU.Data;
using EFKomNU.Model;

namespace EFKomNU.Pages.Kompetence
{
    public class CreateModel : PageModel
    {
        private readonly EFKomNU.Data.UnikContext _context;

        public CreateModel(EFKomNU.Data.UnikContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Model.Kompetence Kompetence { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.KompetenceEntities.Add(Kompetence);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
