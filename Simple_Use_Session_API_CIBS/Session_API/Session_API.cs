using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Configuration;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Text;
using Newtonsoft.Json;
//using System.Web.SessionState;
using System.Web.Script.Serialization;
using Simple_Use_Session_API_CIBS.Session_API;
using Simple_Use_Session_API_CIBS.Models;


namespace Simple_Use_Session_API_CIBS.Session_API
{
    public class Session_API
    {
        //Call for Get All user from API
        public List<TSI_USERS_Model> getAllSession()
        {
            string stringres = string.Empty;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:8085/api/session/GetAllSession");
            request.Method = "GET";
            var text = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                text = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                var data = Encoding.UTF8.GetBytes(text);
                string result = Encoding.UTF8.GetString(data);
                var _response = JsonConvert.DeserializeObject<List<TSI_USERS_Model>>(result); //convert to serializeObject                                                                                              
                return _response;
            }
        }

        //Call for Get user from API by EMPLOYEE_CODE
        public TSI_USERS_Model getSession(string EMP_CODE)
        {
            string stringres = string.Empty;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:8085/api/session/GetSession/" + EMP_CODE);
            request.Method = "GET";
            var text = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                text = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                var data = Encoding.UTF8.GetBytes(text);
                string result = Encoding.UTF8.GetString(data);
                var _response = JsonConvert.DeserializeObject<TSI_USERS_Model>(result); //convert to serializeObject                                                                                              
                return _response;
            }
        }

        //Call for Insert and Update user to API
        public void postSession(TSI_USERS_Model _user)
        {
            //var user = ENCRYPTION.base64Encode(JsonConvert.SerializeObject(_user).ToString());
            //var s = user.Length;
            var s = Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_user).ToString()));
            var url = "http://localhost:8085/api/session/Get_4Post?_u=" + Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_user).ToString()));
            string stringres = string.Empty;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.ContentType = "text/json";
            request.Method = "GET";
            var text = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                text = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                //var data = Encoding.UTF8.GetBytes(text);
                //string result = Encoding.UTF8.GetString(data);
                //var _response = JsonConvert.DeserializeObject<TSI_USERS_Model>(result); //convert to serializeObject                                                                                              
                //return _response;
            }
        }

        //Check time stamp and LoginNow
        public bool checkStateSession(TSI_USERS_Model _user)
        {
            if (!_user.LogginNow)
                return false;
            else
            {
                DateTime WhenLogin = DateTime.Now;
                DateTime LastTimeStamp = Convert.ToDateTime(_user.TimeStamp);
                if ((WhenLogin - LastTimeStamp).TotalMinutes <= 300)
                    return true;
                else
                    return false;
            }
        }

        //Check last timestamp and login now
        public bool _checkStateSession(TSI_USERS_Model _user)
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
            ///find time out
            //SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
            //int timeout = (int)section.Timeout.TotalMinutes * 1000 * 60;

            HostingEnvironmentSection configSection = (HostingEnvironmentSection)config.GetSection("system.web/hostingEnvironment");
            var idleTimeout = configSection.IdleTimeout.TotalHours;
            //get session user from api
            TSI_USERS_Model _user_fromAPI = getSession(_user.EMPLOYEE_ID);

            //var time = _user_fromAPI.TimeStamp;
            var stay = _user_fromAPI.LogginNow;
            DateTime LastAction = Convert.ToDateTime(_user_fromAPI.TimeStamp);
            double Cal_lastAction = (DateTime.Now - LastAction).TotalHours;
            if (Cal_lastAction > idleTimeout) // true for user session is null
                return true;
            else
                return false;
        }
    }
}