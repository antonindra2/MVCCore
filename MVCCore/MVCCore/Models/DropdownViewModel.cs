using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.Models
{
    public class DropdownViewModel
    {
        public IList<SelectListItem> Grade { get; set; }

        public string SelectGrade { get; set; }

        public Grade grades { get; set; }
        public Student students { get; set; }
    }
}
