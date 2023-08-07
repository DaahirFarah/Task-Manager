using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskM.Models;

namespace TaskM.Controllers
{
    public class TasksController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Tasks
        public ActionResult Index()
        {
            var tasks = db.Tasks.ToList();
            return View(tasks);
        }

        // Create Controller, GET Method
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        // SET method for task creation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind (Include = "TaskId, TaskName, TaskDesc, TaskPri")] Task task)
        {
            if(ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(task);
        }


        // GET method for Edit
        public ActionResult Edit(int? Id)
        {
            if(Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(Id);
            if(task == null)
            {
                return HttpNotFound();
            }

            return View(task);
        }


        // SET method for Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskId,TaskName,TaskDesc,TaskPri")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        public ActionResult Delete(int? Id)
        {
            if(Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Task task = db.Tasks.Find(Id);
            if(task == null)
            {
                return HttpNotFound();         
            }

            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            Task task = db.Tasks.Find(Id);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}