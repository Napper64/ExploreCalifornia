using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.ViewComponents {

    public class MonthlySpecialsViewComponent : ViewComponent {

        private readonly SpecialsDataContext _specials;

        public MonthlySpecialsViewComponent(SpecialsDataContext specials)
        {
            this._specials = specials;
        }

        public IViewComponentResult Invoke()
        {
            IList<Special> specials = _specials.GetMonthlySpecials().ToList();
            return View(specials);
        }
    }
}
