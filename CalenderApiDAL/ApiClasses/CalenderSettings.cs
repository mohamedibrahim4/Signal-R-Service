using System;
using System.Collections.Generic;
using System.Text;

namespace CalenderApiDAL.ApiClasses
{
    public class CalenderSettings
    {
        //public const string Position = "AppSettings";

        public string AppStartTime { get; set; }
        public string AppInterval { get; set; }
        public string AppEndTime { get; set; }
    }
}
