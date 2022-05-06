using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20220424_3Operations
{
    public class OfficeClass
    {
        string _officeid;
        string _officename;
        string _schoolid;
        string _authorizedid;
        public string OfficeID { get => _officeid; set => _officeid = value; }
        public string OfficeName { get => _officename; set => _officename = value; }
        public string SchoolID { get => _schoolid; set => _schoolid = value; }
        public string Authorizedid { get => _authorizedid; set => _authorizedid = value; }
    }
}