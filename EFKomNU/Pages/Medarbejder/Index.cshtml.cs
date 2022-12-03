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
    public class IndexModel : PageModel
    {
        private readonly EFKomNU.Data.UnikContext _context;

        public IndexModel(EFKomNU.Data.UnikContext context)
        {
            _context = context;
        }

        public IList<Model.Medarbejder> Medarbejder { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MedarbejderEntities != null)
            {
                Medarbejder = await _context.MedarbejderEntities.ToListAsync();
            }
        }
    }
}
