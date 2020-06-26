using ASPNETCoreTut.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreTut
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt): base(opt)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<VotingItems> VotingItems { get; set; }
        public DbSet<Vote> Vote { get; set; }
    }
}
