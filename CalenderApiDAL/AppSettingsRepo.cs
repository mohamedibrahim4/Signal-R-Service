using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalenderApiDAL
{
    public class AppSettingsRepo : IAppSettings
    {
        private IConfiguration _Configuration;
        public AppSettingsRepo(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
        public string AppStartTime => _Configuration["AppSettings:AppStartTime"];

        public string AppInterval => _Configuration["AppSettings:AppInterval"];

        public string AppEndTime => _Configuration["AppSettings:AppEndTime"];
    }
}
