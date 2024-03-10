using Microsoft.AspNetCore.Mvc;
using GoalTracker.Data;
using GoalTracker.Models;
using GoalTracker.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Headers;
using GoalTracker.Models.ViewModels;
using System.Security.Cryptography;

namespace GoalTracker.Controllers
{
    public class GoalController : Controller
    {
        private readonly IUnitOfWork _iunitOfWork;
        public GoalController(IUnitOfWork iunitOfWork)
        {
            _iunitOfWork = iunitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Goal> tasks = (IEnumerable<Goal>)_iunitOfWork.Goal.GetAll(includeProperties:"Student").OrderBy(x =>x.Deadline).ToList();
            tasks = tasks.Where(x => x.IsCompleted == false).ToList();

            return View(tasks);
        }


        public IActionResult CompletedTasks(bool IsCompleted)
        {
            IEnumerable<Goal> tasks = (IEnumerable<Goal>)_iunitOfWork.Goal.GetAll(includeProperties: "Student").ToList();

            List<Goal> completedTasks;



            completedTasks = tasks.Where(p => p.IsCompleted == true).ToList();

            


            return View(completedTasks);

         
           
        }


        public IActionResult Add() 
        {
            IEnumerable<SelectListItem> StudentList = (IEnumerable<SelectListItem>)_iunitOfWork.Student.GetAll()
              .Select(u => new SelectListItem
              {
                  Text = u.Name,
                  Value = u.Id.ToString()

              });

            GoalVM goalVm = new()
            {
                StudentList = StudentList,
                Goal = new Goal()
            };
            return View(goalVm);
        }

        [HttpPost]
        public IActionResult Add(Goal goal)
        {
            _iunitOfWork.Goal.Add(goal);
            _iunitOfWork.Save();
            return RedirectToAction("Details", "Student", new { id = goal.StudentId });
        }



        public IActionResult Edit(int? id)
        { 
            Goal goalFromDb = _iunitOfWork.Goal.Get(x => x.Id == id);
            return View(goalFromDb);
        }


        [HttpPost]
        public IActionResult Edit(Goal goal)
        {
            _iunitOfWork.Goal.Update(goal);
            _iunitOfWork.Save();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CompleteTask(int? id)
        {
            Goal goalFromDb = _iunitOfWork.Goal.Get(x => x.Id == id);
            goalFromDb.IsCompleted = true;
            // _db.Update(goalFromDb);
            _iunitOfWork.Save();
            return RedirectToAction("Details", "Student", new { id = goalFromDb.StudentId });

        }

        public IActionResult Delete(int? id)
        {
            Goal goalFromDb = _iunitOfWork.Goal.Get(x => x.Id == id);
            return View(goalFromDb);
        }


        [HttpPost]

        public IActionResult Delete(Goal obj)
        {
            _iunitOfWork.Goal.Delete(obj);
            _iunitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
