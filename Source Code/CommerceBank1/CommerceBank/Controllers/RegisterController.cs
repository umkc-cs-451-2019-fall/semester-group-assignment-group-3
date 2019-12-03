using CommerceBank.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommerceBank.Controllers
{
    public class RegisterController : Controller
    {
        private readonly CommerceBankContext _context;

        public RegisterController(CommerceBankContext context)
        {
            _context = context;
        }
    }
}
