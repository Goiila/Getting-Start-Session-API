using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Simple_Use_Session_API_CIBS.Session_API;
using Simple_Use_Session_API_CIBS.Models;

namespace Simple_Use_Session_API_CIBS.Controllers
{
    public class HomeController : Controller
    {
        //Call class Session API
        Session_API.Session_API _session = new Session_API.Session_API();

        // GET: Home
        public ActionResult Index(string u)
        {
            string user_code = u ?? string.Empty;
            var user_all = _session.getAllSession();
            var user_person = _session.getSession(user_code);
            if (user_person == null || ((double)(DateTime.Now - Convert.ToDateTime(user_person.LAST_CHANGED)).TotalDays >= 90) || _session._checkStateSession(user_person) || !_session.getSession(user_person.EMPLOYEE_ID).LogginNow)
            {
                //Go to clear value in session 
                _session.postSession(new TSI_USERS_Model { EMPLOYEE_ID = u, LogginNow = false, TimeStamp = DateTime.Now });
                return Redirect("http://localhost:85/Login/Logout?e=" + Convert.ToBase64String(Encoding.UTF8.GetBytes(user_code)));
            }
            var _sessionAll = user_all;
            foreach (var rows in _sessionAll)
            {
                rows.stayinweb = _session.checkStateSession(rows);
            }
            ViewBag.SessionAll = _sessionAll;
            ViewBag.sessionbyID = _session.getSession(user_code);
            return View();
        }

        public ActionResult Logout(string emp_code)
        {
            //_session.postSession(new Models.TSI_USERS_Model { EMPLOYEE_ID = emp_code, LogginNow = false });
            var _temp_emp_code = Encoding.UTF8.GetString(Convert.FromBase64String(emp_code));
            Session.Clear();
            return Redirect("http://localhost:85/Login/Logout?e="+emp_code);
            //return RedirectToAction("Index", "Home");
        }

    }
}