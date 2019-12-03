using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginFormWithSession.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }
        public string Msg { get; private set; }

        public void OnGet()
        {

        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("username");
            return Page();
        }


        public IActionResult OnPost()
        {
            if(Username.Equals("abc")&& Password.Equals("def"))
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