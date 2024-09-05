using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentViewTemplateDemo.Models;

namespace StudentViewTemplateDemo.Controllers
{
    public class StudentController : Controller
    {
        static List<Student> students = new List<Student>()
        {
            new Student(){Id=1, Name="Sreerag", Age = 30, Address=new Address()
            {Id=1, City="Kochi", Country="India", State="Kerala"}},

            new Student(){Id=2, Name="Ramesh", Age = 30, Address=new Address()
            {Id=2, City="Chennai", Country="India", State="Tamil Nadu"}},

            new Student(){Id=3, Name="Singh", Age = 30, Address=new Address()
            {Id=3, City="Varanasi", Country="India", State="UP"}}
        };
        // GET: Student
        public ActionResult Index()
        {
            
            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                students.Add(student);
                return RedirectToAction("Index");
            }
            return View();
            
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            
            var student = students.FirstOrDefault(s => s.Id == id);
            
            return View(student);
                
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student updatedStudent)
        {
            if(ModelState.IsValid) {  
                var student = students.FirstOrDefault(s => s.Id == id);

                student.Name = updatedStudent.Name;
                student.Age = updatedStudent.Age;
                student.Address = updatedStudent.Address;

                return RedirectToAction("Index");
            }
            return View();
            
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                var student = students.FirstOrDefault(s => s.Id == id);

                students.Remove(student);
                return RedirectToAction("Index");
            }
            return View();
            
        }

        public ActionResult GetStudentAddressById(int id)
        {
            var data = students.Where(st => st.Id == id).Select(st => st.Address).FirstOrDefault();
            return View(data);
        }
        public ActionResult EditAddress(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            
            var address = student.Address;
            return View(address);
        }

        [HttpPost]
        public ActionResult EditAddress(int id, Address updatedAddress)
        {
            if (ModelState.IsValid)
            {

                var student = students.FirstOrDefault(s => s.Id == id);


                // Update the address
                student.Address.City = updatedAddress.City;
                student.Address.State = updatedAddress.State;
                student.Address.Country = updatedAddress.Country;

                return RedirectToAction("GetStudentAddressById", new { id = student.Id });
            }
            return View(updatedAddress);

        }

        public ActionResult DeleteAddress(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            var address = student.Address;

            return View(address);
        }
        [HttpPost]
        public ActionResult DeleteAddress(int id, Address updatedAddress)
        {
           
                var student = students.FirstOrDefault(s => s.Id == id);


                // Update the address
                student.Address.City = null;
                student.Address.State = null;
                student.Address.Country = null;

                return RedirectToAction("GetStudentAddressById", new { id = student.Id });
            
            return View(updatedAddress);

        }



    }
}