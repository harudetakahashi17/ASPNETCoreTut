using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASPNETCoreTut;
using ASPNETCoreTut.Models;

namespace ASPNETCoreTut.Pages.AdminLogin
{
    public class CreateModel : PageModel
    {
        private readonly ASPNETCoreTut.AppDbContext _context;

        public CreateModel(ASPNETCoreTut.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public VotingItems VotingItems { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.VotingItems.Add(VotingItems);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
