using CoreAjax.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreAjax.Controllers
{
   public class StudentsController : Controller
   {
      private readonly ModelManager _context;
      public StudentsController(ModelManager context)
      {
         _context = context;
      }
      public IActionResult Index()
      {
         return View();
      }
      //[HttpGet]
      //[Produces("application/json")]
      public IActionResult Get()
      {
         var allData = _context.Students.ToList();
         return Json(new { data = allData });
         //return Json(allData);
      }

      public IActionResult GetbyID(int id)
      {
         //return Json(_context.Students.Find(id));
         return Json(new { data = _context.Students.Find(id) });
      }
      public JsonResult Update(Student student)
      {

         _context.Students.Update(student);
         _context.SaveChanges();
         return Json(new { data = student });
      }
      public JsonResult Save(Student student)
      {
         _context.Students.Add(student);
         _context.SaveChanges();
         //return Json(new { data = student });
         return Json(student);
      }
      [HttpPost]
      public IActionResult Delete(int id)
      {
         var delStudent = _context.Students.Find(id);
         _context.Students.Remove(delStudent);
         _context.SaveChanges();

         //return Json(new { data = student });
         return Json(delStudent);
      }
   }
}
