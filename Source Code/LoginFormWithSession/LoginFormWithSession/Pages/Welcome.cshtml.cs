using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginFormWithSession.Pages
{
    public class WelcomeModel : PageModel
    {
        public string Username;

        public object UserHttpContext { get; private set; }

        public void OnGet()
        {
            Username = HttpContext.Session.GetString("username");

        }
    }
}