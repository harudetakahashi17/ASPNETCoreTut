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
    public class IndexModel : PageModel
    {
        private readonly ASPNETCoreTut.AppDbContext _context;

        public IndexModel(ASPNETCoreTut.AppDbContext context)
        {
            _context = context;
        }

        public IList<VotingItems> VotingItems { get;set; }

        public async Task OnGetAsync()
        {
            VotingItems = await _context.VotingItems.ToListAsync();
        }
    }
}
