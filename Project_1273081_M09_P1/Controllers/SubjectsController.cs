using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_1273081_M09_P1.Models;
using X.PagedList;

namespace Project_1273081_M09_P1.Controllers
{
  
        public class SubjectsController : Controller
        {
        private readonly TeacherDbContext db;
        public SubjectsController(TeacherDbContext db)
            {
                this.db = db;
            }
            
            public async Task<IActionResult> Index(int pg = 1)
            {
                return View(await db.Subjects.Include(x => x.Teacher).ToPagedListAsync(pg, 5));
            }
            public IActionResult Create()
            {
                ViewBag.Teachers = db.Teachers.ToList();
                return View();
            }
            [HttpPost]
            public IActionResult Create(Subject model)
            {
                if (ModelState.IsValid)
                {
                    db.Database.ExecuteSqlInterpolated($"EXEC InsertSubject {model.CourseDuration}, {model.ExrtaClass}, {model.TeacherId}");
                    return RedirectToAction("Index");

                }
                ViewBag.Teachers = db.Teachers.ToList();
                return View(model);
            }


            public IActionResult Edit(int id)
            {
                var data = db.Subjects.FirstOrDefault(x => x.SubjectId == id);
                if (data == null) { return NotFound(); }
                ViewBag.Teachers = db.Teachers.ToList();
                return View(data);
            }
            [HttpPost]
            public IActionResult Edit(Subject model)
            {
                if (ModelState.IsValid)
                {
                    db.Database.ExecuteSqlInterpolated($"EXEC UpdateSubject {model.SubjectId}, {model.CourseDuration}, {model.ExrtaClass}, {model.TeacherId}");
                    return RedirectToAction("Index");

                }
                ViewBag.Teachers = db.Teachers.ToList();
                return View(model);
            }
            [HttpPost]
            public IActionResult Delete(int id)
            {
                db.Database.ExecuteSqlInterpolated($"EXEC DeleteSubject {id}");
                return Json(new { success = true, id });
            }

        }
    }
