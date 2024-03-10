using GoalTracker.Data;
using Microsoft.AspNetCore.Mvc;
using GoalTracker.Models;
using GoalTracker.Data.Repository.IRepository;
using Microsoft.Identity.Client;

namespace GoalTracker.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StudentController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Student> students = _unitOfWork.Student.GetAll().ToList();
            return View(students);
        }


        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var entity = _unitOfWork.Student.Get(s => s.Id == id);
            
            if(entity == null) 
                return NotFound();
            var filteredArray = _unitOfWork.Goal.GetAll().Where(item => item.StudentId == id).ToList();
            return View(filteredArray);
        }



        [HttpPost]
        public IActionResult Add(Student student, IFormFile file)
        {
           string wwwRootPath = _webHostEnvironment.WebRootPath;
            if(file!=null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string studentPath = Path.Combine(wwwRootPath, @"images\student");

                using (var fileStream = new FileStream(Path.Combine(studentPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                student.ImageUrl = @"\images\student\" + fileName;

            }


            _unitOfWork.Student.Add(student);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id, IFormFile file)
        {
            var studentFromDb = _unitOfWork.Student.Get(x => x.Id == id);

            return View(studentFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Student obj , IFormFile file)
        {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string studentPath = Path.Combine(wwwRootPath, @"images\student");

                if (!string.IsNullOrEmpty(obj.ImageUrl))
                {
                    var oldImagePath = Path.Combine(wwwRootPath, obj.ImageUrl.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(studentPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    obj.ImageUrl = @"\images\student\" + fileName;

                }

           

            _unitOfWork.Student.Update(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");

        }


        public IActionResult Delete(int? id)
        {
            var studentFromDb = _unitOfWork.Student.Get(x => x.Id == id);

            return View(studentFromDb);
        }


        [HttpPost]
        public IActionResult Delete(Student obj)
        {

            _unitOfWork.Student.Delete(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");

        }

        #region api calls
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Student> students = _unitOfWork.Student.GetAll().ToList();
            return Json(new { data = students });
        }


        #endregion

    }
}