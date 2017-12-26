using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prism700p5Try.Models
{
    public class TStaff : RealmObject
    {
        public string OfficeName { get; set; }
        public string StaffName { get; set; }

        public string Password { get; set; }


        public TStaff()
        {
            OfficeName = "";
            StaffName = "";
            Password = "";
        }
    }
}
