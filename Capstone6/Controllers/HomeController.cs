using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone6.Models;

namespace Capstone6.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TaskList()
        {
            week6capstone_tasklistEntities ORM = new week6capstone_tasklistEntities();
            ViewBag.Tasks = ORM.tasks.ToList();
            return View();
        }

        public ActionResult AddTask()
        {
            return View();
        }

        public ActionResult SaveTask(task newTask)
        {
            week6capstone_tasklistEntities ORM = new week6capstone_tasklistEntities();
            newTask.userid = 1;
            ORM.tasks.Add(newTask);
            ORM.SaveChanges();
             return RedirectToAction("TaskList");
        }

        public ActionResult EditTask(int taskid)
        {
            week6capstone_tasklistEntities ORM = new week6capstone_tasklistEntities();
            task taskToEdit = ORM.tasks.Find(taskid);
            if(taskToEdit == null)
            {
                return RedirectToAction("TaskList");
            }
            ViewBag.TaskToEdit = taskToEdit;
            return View();
        }

        public ActionResult DeleteTask(int taskid)
        {
            week6capstone_tasklistEntities ORM = new week6capstone_tasklistEntities();
            task taskToDelete = ORM.tasks.Find(taskid);
            ORM.tasks.Remove(taskToDelete);
            ORM.SaveChanges();
            return RedirectToAction("TaskList");
        }
    }
}