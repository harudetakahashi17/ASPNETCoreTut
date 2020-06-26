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
    public class DetailsModel : PageModel
    {
        private readonly ASPNETCoreTut.AppDbContext _context;

        public DetailsModel(ASPNETCoreTut.AppDbContext context)
        {
            _context = context;
        }

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
    }
}
