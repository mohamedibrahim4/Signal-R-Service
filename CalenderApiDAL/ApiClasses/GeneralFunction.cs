using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace CalenderApiDAL.ApiClasses
{
   public class GeneralFunction
    {


        public HeaderData ReadHeaderData(HttpRequestHeaders headers)
        {
            HeaderData header = new HeaderData();
            try
            {
                string apikey = string.Empty;
                string language = string.Empty;
                DateTime CuDate = DateTime.Now;
                byte DevicePlatform = 0;
                if (headers.Contains("apikey"))
                {
                    apikey = headers.GetValues("apikey").First();
                }
                if (headers.Contains("lang"))
                {
                    language = headers.GetValues("lang").First();
                }
                if (headers.Contains("CurrentDate"))
                {
                    CuDate = DateTime.Parse(headers.GetValues("CurrentDate").First());
                }
                header.APIKey = apikey;
                header.CurrentDate = CuDate;
                header.Lang = (language == "ar" ? Language.Arabic : Language.English);
                header.DevicePlatform = DevicePlatform;

            }
            catch
            {

            }
            return header;
        }

        public bool ValidateHeader(HeaderData header)
        {
            return header.APIKey.Trim().ToLower().Equals("EngMohamedIbrahim");
        }
       
    }
}
