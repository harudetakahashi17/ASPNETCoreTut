using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ASPNETCoreTut.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace ASPNETCoreTut.Pages.AdminLogin
{
    public class LoginModel : PageModel
    {
        // Constructor Dependency Injection
        private readonly AppDbContext _db;

        public LoginModel(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Users> Users { get; set; }

        public async Task OnGet()
        {
            Users = await _db.Users.ToListAsync();
        }

        public ActionResult OnPost(string email, string password)
        {
            var emailRgx = new Regex(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$");
            var passRgx = new Regex(@"(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{8,}");
            if(!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                if (emailRgx.IsMatch(email))
                {
                    if (passRgx.IsMatch(password))
                    {
                        // Cek Admin here

                        return RedirectToPage("Index");
                    } else
                    {
                        return BadRequest("Error 400: Password is not valid");
                    }
                } else
                {
                    return BadRequest("Error 400: Email is not valid");
                }
            } else
            {
                return BadRequest("Error 400 : Form is empty");
            }
        }
    }
}