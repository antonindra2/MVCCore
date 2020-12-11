using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCCore.Context;
using MVCCore.Models;

namespace MVCCore.Controllers
{
    public class GradeController : Controller
    {
        MyContext mycontext = new MyContext();

        public IActionResult Index()
        {
            List<Grade> data = this.mycontext.Grades
                .ToList();
            return View(data);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Grade grade)
        {

            if (ModelState.IsValid)
            {
                mycontext.Grades.Add(grade);
                mycontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            Grade data = mycontext.Grades.Where
                (g => g.GradeId == id).FirstOrDefault();
            return View("Create", data);
        }
        [HttpPost]
        public IActionResult Edit(Grade grade)
        {

            if (ModelState.IsValid)
            {
                mycontext.Grades.Update(grade);
                mycontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", grade);
        }
        public IActionResult Delete(int id)
        {
            Grade data = mycontext.Grades.Where
                (g => g.GradeId == id).FirstOrDefault();
            if (data != null)
            {
                mycontext.Grades.Remove(data);
                mycontext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}