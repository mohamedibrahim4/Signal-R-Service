using CalenderApiBLL.Classes;
using ClinicProApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
//using System.Http;

namespace CalenderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAppointmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly CalenderSettings Configuration;

        public ApiAppointmentController(IConfiguration configuration, IOptions<CalenderSettings> options)
        {
            _configuration = configuration;
            Configuration = options.Value;
        }

        //public ConnectionManager(IOptions<CalenderSettings> options)
        //{
        //    Configuration = options.Value;
        //}

        [HttpGet]

        public JsonResult GetAppointmentReason()
        {
            DataTable dt = new DataTable();
            AppointmentReasons App = new AppointmentReasons();
            try
            {
                List<AppointmentReasons> AppointmentReasonsLists = new List<AppointmentReasons>();
                App.ClinicID = 2;

          

                dt = App.GetDataTable(_configuration.GetConnectionString("ClinicProConnectionString"));
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow aRow in dt.Rows)
                    {
                        AppointmentReasons aAppointmentReasons = new AppointmentReasons();
                        aAppointmentReasons.AppointmentReasonsID = Convert.ToInt32(aRow["AppointmentReasonsID"]);
                        aAppointmentReasons.AppointmentReasons_Desc = Convert.ToString(aRow["AppointmentReasons_Desc"]);
                        aAppointmentReasons.ClinicID = Convert.ToInt32(aRow["ClinicID"]);
                        aAppointmentReasons.Color = Convert.ToInt16(aRow["Color"]);
                        aAppointmentReasons.Interval = Convert.ToInt16(aRow["Interval"]);

                        AppointmentReasonsLists.Add(aAppointmentReasons);
                    }

                }
                else
                {
                    //return Content(HttpStatusCode.BadRequest, AppointmentReasonsLists);
                    return new JsonResult(HttpStatusCode.BadRequest, AppointmentReasonsLists);

                }
                //return Ok(AppointmentReasonsLists);
                return new JsonResult(AppointmentReasonsLists);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //[HttpGet]
        //public JsonResult Get()
        //{
        //    string query = @"
        //                   select AppointmentReasonsID,AppointmentReasons as AppointmentReasons_Desc,Color,Interval,ClinicID from AppointmentReasons
        //                    ";

        //    DataTable table = new DataTable();
        //    string sqlDataSource = _configuration.GetConnectionString("ClinicProConnectionString");
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);
        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }

        //    return new JsonResult(table);
        //}

    }
}
