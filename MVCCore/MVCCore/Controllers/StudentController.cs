using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCCore.Context;
using MVCCore.Models;

namespace MVCCore.Controllers
{
    public class StudentController : Controller
    {
        MyContext mycontext = new MyContext();
        //public StudentController(MyContext context)
        //{
        //    mycontext = context;
        //}

        public IActionResult Index()
        {
            List<Student> data = this.mycontext.Students
               .ToList();
            return View(data);
        }

        //public IActionResult Create()
        //{
        //    DropdownViewModel dropdownViewModel = new DropdownViewModel();
        //    using (var context = new MyContext())
        //    {
        //        dropdownViewModel.Grade = context.Grades.
        //            Select(a => new SelectListItem
        //            {
        //                Text = a.Name,
        //                Value = a.Name
        //            }).ToList();
        //    }
        //    return View(dropdownViewModel);
        //}


        public IActionResult Create()
        {
            List<Grade> data = new List<Grade>();
            data = mycontext.Grades.ToList();
            data.Insert(0, new Grade { GradeId = 0, Name = "Select" });
            ViewBag.ListofGrade = data;
            return View();
        }

        //public IActionResult Create(Student student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        mycontext.Students.Add(student);
        //        mycontext.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
           
        //}
        //public IActionResult Edit(int id)
        //{
        //    Student data = mycontext.Students.Where
        //        (s => s.StudentId == id).FirstOrDefault();
        //    return View("Create", data);
        //}

        //public IActionResult Edit(Student student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        mycontext.Students.Add(student);
        //        mycontext.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View();

        //}

        public IActionResult Delete(int id)
        {
            Student data = mycontext.Students.Where
                (s => s.StudentId == id).FirstOrDefault();
            if (data != null)
            {
                mycontext.Students.Remove(data);
                mycontext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}