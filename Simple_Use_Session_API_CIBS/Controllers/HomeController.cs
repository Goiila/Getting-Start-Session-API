using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Simple_Use_Session_API_CIBS.Session_API;
using System.Web.Mvc;

namespace Simple_Use_Session_API_CIBS.Controllers
{
    public class HomeController : Controller
    {
        //Call class Session API
        Session_API.Session_API _session = new Session_API.Session_API();

        // GET: Home
        public ActionResult Index()
        {

            var _sessionAll = _session.getAllSession();
            foreach (var rows in _sessionAll)
            {
                rows.stayinweb = _session.checkStateSession(rows);
            }
            ViewBag.SessionAll = _sessionAll;
            ViewBag.sessionbyID = _session.getSession("61005");
            
            return View();
        }

        public ActionResult Logout(string emp_code)
        {
            //_session.postSession(new Models.TSI_USERS_Model { EMPLOYEE_ID = emp_code, LogginNow = false });
            var _temp_emp_code = Encoding.Unicode.GetString(Convert.FromBase64String(emp_code));
            Session.Clear();
            return Redirect("http://localhost:85/Login/Logout?e="+emp_code);
            //return RedirectToAction("Index", "Home");
        }

    }
}