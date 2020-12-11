﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.Models
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }
        public string Name { get; set; }

        //public IEnumerable<SelectListItem> grade { get; set; }

        public ICollection<Student> students { get; set; }

    }
}
