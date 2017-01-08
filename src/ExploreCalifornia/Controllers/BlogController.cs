using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExploreCalifornia.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ExploreCalifornia.Controllers {
    [Route("Blog")]
    public class BlogController : Controller {
        public IActionResult Index() {
            return View();
        }

        [Route("{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, string key) {
            Post post = new Post {
                Title = "My blog post",
                Posted = DateTime.Now,
                Author = "Niall McCarthy",
                Body = "This is the body",
            };

            return View(post);
        }
    }
}
