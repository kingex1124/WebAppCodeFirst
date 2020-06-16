using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppCodeFirst.Models;

namespace WebAppCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        private CodeFirstModel _db;
        // GET: Home
        public ActionResult Index()
        {
            _db = new CodeFirstModel();
            //_db.Entry(User).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            return View();
        }
    }
}