using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASPNETCoreTut;
using ASPNETCoreTut.Models;

namespace ASPNETCoreTut.Pages.AdminLogin
{
    public class DeleteModel : PageModel
    {
        private readonly ASPNETCoreTut.AppDbContext _context;

        public DeleteModel(ASPNETCoreTut.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VotingItems VotingItems { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VotingItems = await _context.VotingItems.FirstOrDefaultAsync(m => m.ItemID == id);

            if (VotingItems == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VotingItems = await _context.VotingItems.FindAsync(id);

            if (VotingItems != null)
            {
                _context.VotingItems.Remove(VotingItems);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
