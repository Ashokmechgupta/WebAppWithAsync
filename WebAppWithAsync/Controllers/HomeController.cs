using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebAppWithAsync.Controllers
{
    public class HomeController : Controller
    {
        BATCH_1995Entities db = new BATCH_1995Entities();
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var listdata = await db.STUDENT_TBL.ToListAsync();
            return View(listdata);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Createe(STUDENT_TBL sTUDENT_TBL)
        {
            if(ModelState.IsValid)
            {
                db.STUDENT_TBL.Add(sTUDENT_TBL);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}