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
            return View("Index");
        }
        public ActionResult Edit(int Habit_id)
        {
            DBManager obj = new DBManager();
            Habit_ habit = obj.Gethabit(Habit_id);
            return View(habit);
        }


    }
}