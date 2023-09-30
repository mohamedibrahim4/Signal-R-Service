using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using CalenderApiDAL.ApiClasses;

namespace ClinicProApi
{
    public  class ConnectionManager
    {
     
        //private  readonly CalenderSettings Configuration;

        //public ConnectionManager(IOptions<CalenderSettings> options)
        //{
        //    Configuration = options.Value;
        //}

        //public string GetConnection2()
        //{
        //    var x = Configuration.AppEndTime;
        //    return x;
        //}

        public static SqlConnection GetConnection(string DBConString = "")
        {

            //string connectionString= DBConString;
          
            //if (DBConString == "")
            //{

            //    connectionString = ConfigurationManager.ConnectionStrings["ClinicProConnectionString"].ToString();
            //}
            //else
            //{
            //    connectionString = ConfigurationManager.ConnectionStrings["ClinicProImagingCon"].ToString();
            //}

            //"Data Source=safwat;Initial Catalog=ClinicPro;Persist Security Info=True;User ID=sa;Password=p@ssw0rd";
            //ConfigurationSettings.AppSettings["GOVCOMConnectionString"];
            //System.Configuration
            // Create a new connection object
            SqlConnection connection = new SqlConnection(DBConString);

            // Handle connection events
            //connection.StateChange += Logger.LogConnectionStateChange;
            //connection.InfoMessage += Logger.LogConnectionInfoMessage;

            // Open the connection, and return it
            connection.Open();
            return connection;
        }


    }
}