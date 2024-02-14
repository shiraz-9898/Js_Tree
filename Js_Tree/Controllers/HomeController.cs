using Js_Tree.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Js_Tree.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TreeDbContext _context;

        public HomeController(ILogger<HomeController> logger, TreeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult show() { 
            var data = _context.Trees.ToList();
            return Json(data);
        }
        [HttpPost]
        public IActionResult Add(Tree obj)
        {
           if(ModelState.IsValid)
            {
                _context.Trees.Add(obj);
                _context.SaveChanges();
            }
            return Json(obj);
        }
        [HttpPost]
        public IActionResult Delete(Tree obj)
        {
            if (ModelState.IsValid)
            {
                var data = _context.Trees.Find(obj.Id);
                if(data != null)
                {
                    _context.Trees.Remove(data);
                    _context.SaveChanges();
                }                
            }
            var records = _context.Trees.ToList();
            return Json(records);
        }
        [HttpPost]
        public IActionResult Update(Tree obj)
        {
            if (ModelState.IsValid)
            {
                _context.Trees.Update(obj);
                _context.SaveChanges();
            }
            var records = _context.Trees.ToList();
            return Json(records);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
