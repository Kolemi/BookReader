using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace BookReader.Pages.Admin
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Msg { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Username.Equals("abc") && Password.Equals("123"))
            {
                HttpContext.Session.SetString("username", Username);
                return RedirectToPage("Welcome");
            }
            else
            {
                Msg = "Invalid";
                return Page();
            }
        }
    }
}