using Habit_Master.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Habit_Master.Controllers
{
    public class HabitsController : Controller
    {
        // GET: Habits
        public ActionResult Index()
        {
            DBManager dbManager = new DBManager();
            List<Habit_> models = new List<Habit_>();
            models = dbManager.GetHabits();
            return View(models);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Habit_ h)
        {
            DBManager db = new DBManager();
            db.SaveHabit(h);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            DBManager obj = new DBManager();
            Habit_ habit = obj.Gethabit(id);
            return View(habit);
        }
        [HttpPost]
        public ActionResult Edit(Habit_ habit_)
        {
            DBManager obj = new DBManager();
            obj.Update(habit_.Habit_Id,habit_);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            DBManager obj = new DBManager();
            obj.Delete_Habit(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UpdateHabitCheck(int id, bool isChecked)
        {
            DBManager obj = new DBManager();
            obj.Update_HabitCheck(id, isChecked);
            return Json(new { success = true });
        }


    }
}