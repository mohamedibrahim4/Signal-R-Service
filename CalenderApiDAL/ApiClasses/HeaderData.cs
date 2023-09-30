using System;
using System.Collections.Generic;
using System.Text;

namespace CalenderApiDAL.ApiClasses
{
    public class HeaderData
    {
        public DateTime CurrentDate { get; set; }
        public string APIKey { get; set; }
        public Language Lang { get; set; }
        public byte DevicePlatform { get; set; }
    }
    public enum Language
    {
        Arabic = 1, English = 2
    }
}
