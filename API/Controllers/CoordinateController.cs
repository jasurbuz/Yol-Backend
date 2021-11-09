using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yol.API.Controllers
{
    public class CoordinateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
