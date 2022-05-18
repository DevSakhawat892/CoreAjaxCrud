using CoreAjax.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreAjax.Controllers
{
   public class DepartmentsController : Controller
   {
      private readonly ModelManager _context;
      public DepartmentsController(ModelManager context)
      {
         _context = context;
      }
      public IActionResult Index()
      {
         return View(_context.Departments.ToList());
      }
      [HttpGet]
      public IActionResult Create()
      {
         return View();
      }
      [HttpPost]
      public IActionResult Create(Department department)
      {
         _context.Departments.Add(department);
         if (_context.SaveChanges() > 0)
         {
            return RedirectToAction(nameof(Index));
         }
         return View(department);
      }

      //public IActionResult Index()
      //{
      //   return View(_context.Departments.ToList());
      //}
   }
}
