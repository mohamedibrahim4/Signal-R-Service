using System;
using System.Collections.Generic;
using System.Text;

namespace CalenderApiDAL
{
   public interface IAppSettings
    {
        public string AppStartTime { get;}
        public string AppInterval { get;  }
        public string AppEndTime { get; }
    }
}
