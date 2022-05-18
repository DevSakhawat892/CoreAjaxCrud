using CoreAjax.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAjax.Controllers
{
   public class TransectionModelsController : Controller
   {
      private readonly ModelManager _context;

      public TransectionModelsController(ModelManager context)
      {
         _context = context;
      }

      public async Task<IActionResult> Index()
      {
         return View(await _context.TransectionModels.ToListAsync());
      }

      //public async Task<IActionResult> Details(int? id)
      //{
      //   if (id == null)
      //   {
      //      return NotFound();
      //   }

      //   var transectionModel = await _context.TransectionModels
      //       .FirstOrDefaultAsync(m => m.TransactionId == id);
      //   if (transectionModel == null)
      //   {
      //      return NotFound();
      //   }

      //   return View(transectionModel);
      //}

      //public IActionResult Create()
      //{
      //   return View();
      //}

      [HttpPost]
      [ValidateAntiForgeryToken]
      public JsonResult Create(TransectionModel transectionModel)
      {
         if (ModelState.IsValid)
         {
            _context.Add(transectionModel);
            if (_context.SaveChanges() > 0)
            {
               return Json(new { Data = transectionModel, Issuccess = true });
            }
         }
         //return View(transectionModel);
         return Json(new { Data = new TransectionModel(), Issuccess = false });
      }


      public async Task<IActionResult> Edit(int? id)
      {
         if (id == null)
         {
            return NotFound();
         }

         var transectionModel = await _context.TransectionModels.FindAsync(id);
         if (transectionModel == null)
         {
            return NotFound();
         }
         return View(transectionModel);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(int id, TransectionModel transectionModel)
      {
         if (id != transectionModel.TransactionId)
         {
            return NotFound();
         }

         if (ModelState.IsValid)
         {
            try
            {
               _context.Update(transectionModel);
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               if (!TransectionModelExists(transectionModel.TransactionId))
               {
                  return NotFound();
               }
               else
               {
                  throw;
               }
            }
            return RedirectToAction(nameof(Index));
         }
         return View(transectionModel);
      }

      public async Task<IActionResult> Delete(int? id)
      {
         if (id == null)
         {
            return NotFound();
         }

         var transectionModel = await _context.TransectionModels
             .FirstOrDefaultAsync(m => m.TransactionId == id);
         if (transectionModel == null)
         {
            return NotFound();
         }

         return View(transectionModel);
      }


      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(int id)
      {
         var transectionModel = await _context.TransectionModels.FindAsync(id);
         _context.TransectionModels.Remove(transectionModel);
         await _context.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
      }

      private bool TransectionModelExists(int id)
      {
         return _context.TransectionModels.Any(e => e.TransactionId == id);
      }
   }
}
