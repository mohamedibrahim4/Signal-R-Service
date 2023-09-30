using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ClinicProApi
{
    public class GeneralFunctionDAC
    {
      

        public static bool DMLStatment(string SQLStr, string DBConString = "")
        {

            try
            {


                using (SqlConnection connection = ConnectionManager.GetConnection(DBConString))
                {
                    using (SqlCommand command = new SqlCommand(SQLStr, connection))
                    {
                        command.CommandType = CommandType.Text;

                        if (command.ExecuteNonQuery() <= 0)
                        { return false; }
                        else
                        { return true; }
                    }
                }
            }
            catch (Exception e)
            { throw e; }

        }
        public static DataSet DDLStatment(string SQLStr, string dt, string DBConString = "")
        {
            try
            {
                DataSet ds = new DataSet();

                using (SqlConnection connection = ConnectionManager.GetConnection(DBConString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(SQLStr, connection))
                    {
                        da.Fill(ds, dt);
                        return ds;
                    }

                }

                //Return ds
            }
            catch (Exception e)
            { throw e; }
        }
        public static DataSet DDLSPStatment(string SQLStr, string dt)
        {
            try
            {
                DataSet ds = new DataSet();

                using (SqlConnection connection = ConnectionManager.GetConnection())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        using (SqlCommand cmd = new SqlCommand(SQLStr, connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            da.SelectCommand = cmd;

                            da.Fill(ds, dt);
                            return ds;

                        }
                    }

                }

                //Return ds
            }
            catch (Exception e)
            { throw e; }
        }
        public static DataSet DDLSPStatmentWithPar(string SQLStr, string dt, SqlParameter[] par)
        {
            try
            {
                DataSet ds = new DataSet();

                using (SqlConnection connection = ConnectionManager.GetConnection())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        using (SqlCommand cmd = new SqlCommand(SQLStr, connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            for (int i = 0; i <= par.Length - 1; i++)
                            {
                                //if (IsNumeric(par[i].Value.ToString()) == true)
                                //{
                                if (par[i].Value == null)
                                    par[i].Value = DBNull.Value;

                                //}
                                else
                                {
                                    if (par[i].Value.ToString() == "")
                                        par[i].Value = DBNull.Value;

                                }
                                cmd.Parameters.Add(par[i]);
                            }

                            da.SelectCommand = cmd;

                            da.Fill(ds, dt);
                            return ds;

                        }
                    }

                }

                //Return ds
            }
            catch (Exception e)
            { throw e; }
        }
        public static DataSet DDLSPStatmentWithPar(string SQLStr, string dt)
        {
            try
            {
                DataSet ds = new DataSet();

                using (SqlConnection connection = ConnectionManager.GetConnection())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        using (SqlCommand cmd = new SqlCommand(SQLStr, connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            da.SelectCommand = cmd;

                            da.Fill(ds, dt);
                            return ds;

                        }
                    }

                }

                //Return ds
            }
            catch (Exception e)
            { throw e; }
        }
        public static bool IsDate(string sdate)
        {
            DateTime dt;
            bool isDate = true;
            try
            {
                dt = DateTime.Parse(sdate);
            }
            catch
            {
                isDate = false;
            }
            return isDate;
        }
        public static bool IsNumeric(string theValue)
        {
            try
            {
                Convert.ToInt32(theValue);
                return true;
            }
            catch
            {
                return false;
            }
        } //IsNumeric     
        public static SqlDataReader DMLSPReaderWithPar(string SPName, SqlParameter[] par)

        {
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ClinicProCon"].ToString();

            try
            {

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                using (SqlCommand command = new SqlCommand(SPName, connection))
                {

                    command.CommandType = CommandType.StoredProcedure;


                    for (int i = 0; i <= par.Length - 1; i++)
                    {
                        if (IsNumeric(par[i].Value.ToString()) == true)
                        {
                            if (par[i].Value == null)
                                par[i].Value = DBNull.Value;

                        }
                        else
                        {
                            if (par[i].Value.ToString() == "")
                                par[i].Value = DBNull.Value;

                        }
                        command.Parameters.Add(par[i]);
                    }

                    reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                }
                return reader;
            }
            catch (Exception ex)
            { throw ex; }

            finally
            { connectionString = null; }
        }
        public static SqlDataReader DMLSPReader(string SPName)
        {
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ClinicProCon"].ToString();
            try
            {

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                using (SqlCommand command = new SqlCommand(SPName, connection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                }
                return reader;
            }
            catch (Exception ex)
            { throw ex; }

            finally
            { connectionString = null; }
        }
        public static SqlDataReader DDLReader(string SQLStr)
        {
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["ClinicProCon"].ToString();
            try
            {

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                using (SqlCommand command = new SqlCommand(SQLStr, connection))
                {

                    command.CommandType = CommandType.Text;
                    reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                }
                return reader;
            }
            catch (Exception ex)
            { throw ex; }

            finally
            { connectionString = null; }
        }
        public static object DDLScalarReader(string SQLStr)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ClinicProCon"].ToString();
            SqlConnection connection = new SqlConnection();
            try
            {

                connection.ConnectionString = connectionString;
                connection.Open();

                using (SqlCommand command = new SqlCommand(SQLStr, connection))
                {

                    command.CommandType = CommandType.Text;
                    return command.ExecuteScalar();

                }

            }
            catch (Exception ex)
            { throw ex; }

            finally
            {
                connectionString = null;
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Dispose();
            }
        }
        public static object DDLScalarReaderWithPar(string SPName, SqlParameter[] par)

        {

            string connectionString = ConfigurationManager.ConnectionStrings["ClinicProCon"].ToString();
            // SqlConnection connection;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // connection = new SqlConnection(connectionString);
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SPName, connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;


                        for (int i = 0; i <= par.Length - 1; i++)
                        {
                            if (IsNumeric(par[i].Value.ToString()) == true)
                            {
                                if (par[i].Value == null)
                                    par[i].Value = DBNull.Value;

                            }
                            else
                            {
                                if (par[i].Value.ToString() == "")
                                    par[i].Value = DBNull.Value;

                            }
                            command.Parameters.Add(par[i]);
                        }

                        return command.ExecuteScalar();

                    }
                }

            }
            catch (Exception ex)
            { throw ex; }

            finally
            {
                //if (connection.State != ConnectionState.Closed)
                //{
                //    connection.Close();
                //}
                //connection = null;
                connectionString = null;
            }
        }
        public static string FindStr(String ProssID)
        {

            switch (ProssID)
            {
                case "A":
                    return "SH";
                case "B":
                    return "EY";
                case "C":
                    return "AD";
                case "D":
                    return "AHD";
                case "E":
                    return "ZO";
                case "F":
                    return "DOOF";
                case "G":
                    return "DOOG";
                case "H":
                    return "SAF";
                case "I":
                    return "DNI";
                case "j":
                    return "OODSJ";
                case "K":
                    return "KATI";
                case "L":
                    return "ONG";
                case "M":
                    return "MOON";
                case "N":
                    return "NINE";
                case "O":
                    return "OMI";
                case "P":
                    return "PIMO";
                case "Q":
                    return "NEEN";
                case "R":
                    return "S";
                case "S":
                    return "TAWFAS";
                case "T":
                    return "ABLE";
                case "U":
                    return "OGA";
                case "V":
                    return "AGI";
                case "W":
                    return "ESMAT";
                case "X":
                    return "HEXA";
                case "Y":
                    return "HOGO";
                case "Z":
                    return "ZOOLLL";
                case "0":
                    return "ERT5456FDG3";
                case "1":
                    return "018945KGJI89";
                case "2":
                    return "543WER54312";
                case "3":
                    return "7653DFGERTY2345";
                case "4":
                    return "SDFS3456456DFGFDGDFG";
                case "5":
                    return "345345SDFSDFHJGHJG";
                case "6":
                    return "SDFSD456456SDF";
                case "7":
                    return "DSFSD456456WERWE23423";
                case "8":
                    return "SDFSDF567867SDFSD";
                case "9":
                    return "234242SDFSDFUOUIO";
                default:
                    return ProssID;


            }

        }

        public static string GetMonthStr(Int16 Month)
        {
            try
            {
                switch (Month)
                {
                    case 1:
                        return "Jan";

                    case 2:
                        return "Feb";
                    case 3:
                        return "Mar";
                    case 4:
                        return "Apr";
                    case 5:
                        return "May";
                    case 6:
                        return "Jun";
                    case 7:
                        return "Jul";
                    case 8:
                        return "Aug";
                    case 9:
                        return "Sep";
                    case 10:
                        return "Oct";
                    case 11:
                        return "Nov";
                    case 12:
                        return "Dec";
                    default:
                        return "";
                }
            }
            catch (Exception e)
            { throw e; }
        }

        public static string ConvertSMSToBinary(string input)
        {
            Char[] values = input.ToCharArray();
            StringBuilder hex = new StringBuilder();
            foreach (Char c in values)
            {
                // ' Get the integral value of the character.
                Int32 value = Convert.ToInt32(c);
                // ' Convert the decimal value to a hexadecimal value in string form.
                hex.AppendFormat("{0:X4}", value);
            }


            return hex.ToString();
        }
        public static DataTable DMLSPReaderWithPar3(string SPName, SqlParameter[] par)

        {
            //SqlDataAdapter da = null;
            string connectionString = ConfigurationManager.ConnectionStrings["ClinicProConnectionString"].ToString();


            try
            {

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(SPName, connection);
                DataSet ds = new DataSet();

                using (SqlCommand command = new SqlCommand(SPName, connection))
                {

                    //command.CommandType = CommandType.StoredProcedure;


                    for (int i = 0; i <= par.Length - 1; i++)
                    {
                        if (IsNumeric(par[i].Value.ToString()) == true)
                        {
                            if (par[i].Value == null)
                                par[i].Value = DBNull.Value;

                        }
                        else
                        {
                            if (par[i].Value.ToString() == "")
                                par[i].Value = DBNull.Value;

                        }
                        da.SelectCommand.Parameters.Add(par[i]);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        //connection.Open();

                    }






                }
                da.Fill(ds, "DS");

                return ds.Tables[0];
                //return reader;
            }
            catch (Exception ex)
            { throw ex; }

            finally
            { connectionString = null; }
        }


    }

}        