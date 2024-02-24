using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Data;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
             IEnumerable<Student> students = _db.Students.ToList();
            return View(students);
        }


        public IActionResult Add()
        {


            return View();


        }



        [HttpPost]
        public IActionResult Add(Student student)
        {
           

            _db.Students.Add(student);
            _db.SaveChanges();
            return RedirectToAction("Index");
                   
            
        }

        public IActionResult Edit(int? id)
        {
            var  studentFromDb = _db.Students.FirstOrDefault(x => x.Id == id);

            return View(studentFromDb);


        }

        [HttpPost]
        public IActionResult Edit(Student obj)
        {
            

            _db.Students.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }


        public IActionResult Delete(int? id)
        {
            var studentFromDb = _db.Students.FirstOrDefault(x => x.Id == id);

            return View(studentFromDb);


        }

        [HttpPost]
        public IActionResult Delete(Student obj)
        {


            _db.Students.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }




    }
}