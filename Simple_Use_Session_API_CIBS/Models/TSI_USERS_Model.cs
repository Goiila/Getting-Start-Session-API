using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simple_Use_Session_API_CIBS.Models
{
    public class TSI_USERS_Model
    {
        // Class query data for Edit and other 
        public string ID { get; set; }
        public string PWD { get; set; }
        public string NAME { get; set; }
        public string TEAM { get; set; }
        public string STATUS { get; set; }
        public DateTime? LAST_CHANGED { get; set; }
        public string _LAST_CHANGED { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string EMPLOYEE_CODE { get; set; }
        public string DEPARTMENT { get; set; }
        public string TEAM_LEADER { get; set; }
        public string Email { get; set; }
        public byte[] PWD_ENCRYPTION { get; set; }
        public byte[] PWD_KEY { get; set; }
        public int isUpdate { get; set; }
        public string Request_Date { get; set; }
        public bool HavePicture { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string _TimeStamp { get; set; }
        public bool LogginNow { get; set; }
        public bool stayinweb { get; set; }
    }
}