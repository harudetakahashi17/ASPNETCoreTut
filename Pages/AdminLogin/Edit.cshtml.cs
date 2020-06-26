using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNETCoreTut;
using ASPNETCoreTut.Models;

namespace ASPNETCoreTut.Pages.AdminLogin
{
    public class EditModel : PageModel
    {
        private readonly ASPNETCoreTut.AppDbContext _context;

        public EditModel(ASPNETCoreTut.AppDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(VotingItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VotingItemsExists(VotingItems.ItemID))
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

        private bool VotingItemsExists(int id)
        {
            return _context.VotingItems.Any(e => e.ItemID == id);
        }
    }
}
