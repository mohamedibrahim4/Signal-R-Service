using ClinicProApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CalenderApiBLL.Classes
{
    public class AppointmentReasons

    {
     

        string SQLStr = "";
        public int AppointmentReasonsID { get; set; }
        public string AppointmentReasons_Desc { get; set; }
        public int ClinicID { get; set; }
        public Int16 Color { get; set; }
        public Int16 Interval { get; set; }


        //public List<AppointmentReasons> GetData()
        //{
        //    try
        //    {
        //        SQLStr = "select * from AppointmentReasons";
        //        DataTable dt = new DataTable();
        //        dt = GeneralFunctionDAC.DDLStatment(SQLStr, "AppointmentReasons").Tables[0];
        //        List<AppointmentReasons> reasons = new List<AppointmentReasons>();
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            foreach (DataRow aRow in dt.Rows)
        //            {
        //                AppointmentReasons obj = new AppointmentReasons();
        //                obj.AppointmentReasonsID = Convert.ToInt32(aRow["AppointmentReasonsID"]);
        //                obj.AppointmentReasons_Desc = Convert.ToString(aRow["AppointmentReasons"]);
        //                obj.ClinicID = Convert.ToInt32(aRow["ClinicID"]);
        //                obj.Color = Convert.ToInt16(aRow["Color"]);
        //                obj.Interval = Convert.ToInt16(aRow["Interval"]);
        //                reasons.Add(obj);
        //            }

        //        }
        //        return reasons;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        public DataTable GetDataTable(String DBConString)
        {
            try
            {
                SQLStr = "select AppointmentReasonsID,AppointmentReasons as AppointmentReasons_Desc,Color,Interval,ClinicID from AppointmentReasons";
                return GeneralFunctionDAC.DDLStatment(SQLStr, "AppointmentReasons", DBConString).Tables[0];

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}
