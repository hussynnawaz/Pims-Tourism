using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Configuration;

namespace DTS.Models
{
    public class AdminClass
    {
        public static string ConString()
        {
            //string str = "Data Source=.;Initial Catalog=HotelMS;user id=hotelsbo;password=hotelMS@8563";
            string str = "Data Source=DESKTOP-HQQT8UA;Initial Catalog=HotelMSOnline;Integrated Security=True";
            return str;
        }

        public string DataProcessor(DataKeeper[] data, string action)
        {
            String messag = string.Empty;
            SqlConnection con = null;
            try
            {
                if (HttpContext.Current.Session["UserId"] != null)
                {
                    using (con = new SqlConnection(ConString()))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(action, con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            if (data != null)
                            {
                                foreach (DataKeeper nvp in data)
                                {
                                    string Newvalue = RemoveSpecialChars(nvp.value);
                                    cmd.Parameters.AddWithValue("@" + nvp.name, Newvalue);
                                }
                            }
                            cmd.Parameters.Add("@Response", SqlDbType.VarChar, 200);
                            cmd.Parameters.AddWithValue("@UId", HttpContext.Current.Session["UserId"].ToString());
                            cmd.Parameters["@Response"].Direction = ParameterDirection.Output;

                            cmd.ExecuteNonQuery();
                            messag = cmd.Parameters["@Response"].Value.ToString();
                            con.Close();
                        }
                        return messag;
                    }
                }
                else
                {
                    return "SessionNull";
                }
            }
            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return "Error";
            }

        }


        public string FnSignUp(DataKeeper[] data, string action,string ToEmail)
        {

            String messag = string.Empty;
            SqlConnection con = null;
            try
            {

                using (con = new SqlConnection(ConString()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(action, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                            foreach (DataKeeper nvp in data)
                            {
                                string Newvalue = RemoveSpecialChars(nvp.value);
                                cmd.Parameters.AddWithValue("@" + nvp.name, Newvalue);
                            }
                        
                        cmd.Parameters.AddWithValue("@Email_ID", ToEmail);
                        cmd.Parameters.Add("@Response", SqlDbType.VarChar, 200);

                        cmd.Parameters["@Response"].Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();
                        messag = cmd.Parameters["@Response"].Value.ToString();


                        con.Close();
                    }

                   // Sendmail(ToEmail, messag, "TCKP");
                   
                    return messag;
                    
                }

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message;
            }

        }
        // Reset Password
        public string FnReset(DataKeeper[] data, string action)
        {

            String messag = string.Empty;
            SqlConnection con = null;
            try
            {

                using (con = new SqlConnection(ConString()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(action, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                            foreach (DataKeeper nvp in data)
                            {
                                string Newvalue = RemoveSpecialChars(nvp.value);
                                cmd.Parameters.AddWithValue("@" + nvp.name, Newvalue);
                            }
                        
                        cmd.Parameters.Add("@Response", SqlDbType.VarChar, 200);
                        cmd.Parameters["@Response"].Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();
                        messag = cmd.Parameters["@Response"].Value.ToString();

                        con.Close();
                        messag ="success";
                    }

                  
                   
                     return messag;
                           
                }

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message;
            }

        }
        public string PasswordReset(DataKeeper[] data, string action,string ToEmail)
        {

            DataTable dt1 = null;
            SqlConnection con = null;
            string rows = string.Empty;



            try
            {

                using (con = new SqlConnection(ConString()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(action, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                       
                            foreach (DataKeeper nvp in data)
                            {
                                string Newvalue = RemoveSpecialChars(nvp.value);
                                cmd.Parameters.AddWithValue("@" + nvp.name, Newvalue);

                            }
                        
                        cmd.Parameters.AddWithValue("@Email_ID", ToEmail);
                 
                        //

                        
                       
                        //
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {

                            dt1 = new DataTable();
                            dt1.Load(dr);

                        }
                        con.Close();

                          
                        if (dt1.Rows.Count > 0)
                        {
                            
                           // HttpContext.Current.Session["Id"] = dt1.Rows[0][0].ToString();



                         //   rows = JsonConvert.SerializeObject(dt1);
                      
                           // Sendmail(ToEmail,"Dear"+" "+ dt1.Rows[0][0].ToString()+System.Environment.NewLine+System.Environment.NewLine+"Your request processed for reset Password clink link bellow" + System.Environment.NewLine +"http://localhost:57915/Home/ResetPassword?" + ToEmail+System.Environment.NewLine+System.Environment.NewLine+"Technical Team"+System.Environment.NewLine+"TCKP"+System.Environment.NewLine+"03459523811", "TCKP");
                            rows = "Success";
                            return rows;
                            


                        }
                        else
                        {
                            rows = "Fail ";
                            return rows;
                        }


                    }

                }


            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message;
            }
        }

    
        public string DataProcessor1(DataKeeper[] data, int colms, ArrayDetails[] Details, string action)
        {
            String messag = string.Empty;
            SqlConnection con = null;
            try
            {
                if (HttpContext.Current.Session["UserId"] != null)
                {
                    DataTable dt = new DataTable();
                    for (int i = 0; i < colms; i++)
                    {
                        dt.Columns.Add("Column" + i, typeof(string));
                    }
                    foreach (ArrayDetails Det in Details)
                    {
                        dt.Rows.Add(Det.Parm1, Det.Parm2, Det.Parm3, Det.Parm4, Det.Parm5, Det.Parm6, Det.Parm7);
                    }
                    using (con = new SqlConnection(ConString()))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(action, con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            if (data!= null)
                            {
                                foreach (DataKeeper nvp in data)
                                {
                                    string Newvalue = RemoveSpecialChars(nvp.value);
                                    cmd.Parameters.AddWithValue("@" + nvp.name, Newvalue);
                                }
                            }
                            cmd.Parameters.AddWithValue("@List", dt);
                            cmd.Parameters.AddWithValue("@UId", HttpContext.Current.Session["UserId"].ToString());
                            cmd.Parameters.Add("@Response", SqlDbType.VarChar, 200);
                            cmd.Parameters["@Response"].Direction = ParameterDirection.Output;

                            cmd.ExecuteNonQuery();
                            messag = cmd.Parameters["@Response"].Value.ToString();
                            con.Close();

                            return messag;
                        }
                    }
                }
                else
                {
                    return "SessionNull";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        public class Dt
        {
            public DataTable dt1 { get; set; }
            public DataTable dt2 { get; set; }
            public DataTable dt3 { get; set; }
            public DataTable dt4 { get; set; }
            public DataTable dt5 { get; set; }
        }

        public string DataSelector(DataKeeper[] data, string action)
        {

            DataTable dt1 = null;
            DataTable dt2 = null;
            DataTable dt3 = null;
            DataTable dt4 = null;
            DataTable dt5 = null;
            SqlConnection con = null;
            string rows = string.Empty;

            Dictionary<string, string> para = new Dictionary<string, string>();
            try
            {
                if (HttpContext.Current.Session["UserId"] != null)
                {
                    using (con = new SqlConnection(ConString()))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(action, con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            if (data != null)
                            {
                                foreach (DataKeeper nvp in data)
                                {
                                    string Newvalue = RemoveSpecialChars(nvp.value);
                                    cmd.Parameters.AddWithValue("@" + nvp.name, Newvalue);
                                }
                            }
                            cmd.Parameters.AddWithValue("@UId", HttpContext.Current.Session["UserId"].ToString());
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {

                                dt1 = new DataTable();
                                dt1.Load(dr);
                                dt2 = new DataTable();
                                dt2.Load(dr);
                                dt3 = new DataTable();
                                dt3.Load(dr);
                                dt4 = new DataTable();
                                dt4.Load(dr);
                                dt5 = new DataTable();
                                dt5.Load(dr);
                            }
                            con.Close();
                            Dt AllData = new Dt
                            {
                                dt1 = dt1,
                                dt2 = dt2,
                                dt3 = dt3,
                                dt4 = dt4,
                                dt5 = dt5
                            };
                            rows = JsonConvert.SerializeObject(AllData);
                            return rows;

                        }
                    }
                }
                else
                {
                    return "SessionNull";
                }
            }
            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return "Error";
            }

        }

        public string DataSelectorLess(DataKeeper[] data, string action)
        {

            DataTable dt1 = null;
            SqlConnection con = null;
            string rows = string.Empty;

            //Dictionary<string, string> para = new Dictionary<string, string>();
            try
            {
                if (HttpContext.Current.Session["UserId"] != null)
                {
                    using (con = new SqlConnection(ConString()))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(action, con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            if (data != null)
                            {
                                foreach (DataKeeper nvp in data)
                                {
                                    string Newvalue = RemoveSpecialChars(nvp.value);
                                    cmd.Parameters.AddWithValue("@" + nvp.name, Newvalue);
                                }
                            }
                            cmd.Parameters.AddWithValue("@UId", HttpContext.Current.Session["UserId"].ToString());
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {

                                dt1 = new DataTable();
                                dt1.Load(dr);

                            }
                            con.Close();

                            rows = JsonConvert.SerializeObject(dt1);
                            return rows;

                        }
                    }
                }
                else
                {
                    return "SessionNull";
                }
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message;
            }

        }
        public string DataSelectorGeneral(DataKeeper[] data, string action)
        {

            DataTable dt1 = null;
            SqlConnection con = null;
            string rows = string.Empty;

            //Dictionary<string, string> para = new Dictionary<string, string>();
            try
            {
                using (con = new SqlConnection(ConString()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(action, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (data!= null)
                        {
                            foreach (DataKeeper nvp in data)
                            {
                                string Newvalue = RemoveSpecialChars(nvp.value);
                                cmd.Parameters.AddWithValue("@" + nvp.name, Newvalue);
                            }
                        }
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {

                            dt1 = new DataTable();
                            dt1.Load(dr);

                        }
                        con.Close();

                        rows = JsonConvert.SerializeObject(dt1);
                        return rows;

                    }
                }

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message;
            }

        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
        public static string RemoveSpecialChars(string str)
        {
            if (str == null || str == "")
            {
                return "";

            }
            else
            {
                string[] chars = new string[] { "=", "!", "$", "%", "^", "&", "*", "'", "\"", ";", "(", ")", "|", "[", "]" };
                for (int i = 0; i < chars.Length; i++)
                {
                    if (str.Contains(chars[i]))
                    {
                        str = str.Replace(chars[i], " ");
                    }
                }
                return str;
            }
        }

        public string LoginSelector(DataKeeper[] data, string action)
        {

            DataTable dt1 = null;
            SqlConnection con = null;
            string rows = string.Empty;



            try
            {

                using (con = new SqlConnection(ConString()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(action, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (DataKeeper nvp in data)
                        {
                            string Newvalue = RemoveSpecialChars(nvp.value);
                            cmd.Parameters.AddWithValue("@" + nvp.name, Newvalue);
                        }


                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {

                            dt1 = new DataTable();
                            dt1.Load(dr);

                        }
                        con.Close();
                        if (dt1.Rows.Count > 0)
                        {
                           
                            HttpContext.Current.Session["Name"] = dt1.Rows[0][1].ToString();
                            if (dt1.Rows[0][2].ToString() == "Admin")
                            {
                                rows = "Main," + dt1.Rows[0][1].ToString() + "";
                                HttpContext.Current.Session["UserId"] = dt1.Rows[0][0].ToString();
                            }
                            else if (dt1.Rows[0][2].ToString() == "Inspector")
                            {
                                rows = "InspectorMain," + dt1.Rows[0][1].ToString() + "";
                                HttpContext.Current.Session["InspectorId"] = dt1.Rows[0][0].ToString();
                            }
                            else if (dt1.Rows[0][2].ToString() == "Operator")
                            {
                                rows = "OperatorMain," + dt1.Rows[0][1].ToString() + "";
                                HttpContext.Current.Session["OperatorId"] = dt1.Rows[0][0].ToString();
                            }
                            else
                            {
                                rows = "Designation Not Defined";
                            }
                            return rows;
                        }
                        else
                        {
                            rows = "Incorrect";
                            return rows;
                        }


                    }

                }


            }
            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return "Error";
            }
        }
        public string Logout()
        {
            HttpContext.Current.Session["UserId"] = null;
            if (HttpContext.Current.Session["UserId"] == null)
            {
                return "Index";
            }
            else
            {
                return "Failed";
            }
        
        }
        public string Sendmail(string ToName, string ToEmail,string BusinessName,string BusinessType,string ApplicationNo,string FileNo,string ApplicationDate,string DespositeSlip,string ApplicationRemarks,string ApplicationStatus)
        {
            


            try
            {
                string body="";
                if (ApplicationStatus == "Inspection")
                {
                    body = this.CreateEmailBodyForInspection(ToName, BusinessName, BusinessType, ApplicationNo, FileNo, ApplicationDate, DespositeSlip, ApplicationRemarks);
                }
                else if (ApplicationStatus == "Finding")
                {
                    body = this.CreateEmailBodyForFinding(ToName, BusinessName, BusinessType, ApplicationNo, FileNo, ApplicationDate, DespositeSlip, ApplicationRemarks);
                }
                else if (ApplicationStatus == "Inspector")
                {
                    body = this.CreateEmailBodyForInspector(ToName, BusinessName, BusinessType, ApplicationNo,  ApplicationDate,  ApplicationRemarks);
                }
                else if (ApplicationStatus == "Active")
                {
                    body = this.CreateEmailBodyForRecommended(ToName, BusinessName, BusinessType, ApplicationNo, ApplicationDate);
                }
                else if (ApplicationStatus == "NotApproved")
                {
                    body = this.CreateEmailBodyForNonRecommended(ToName, BusinessName, BusinessType, ApplicationNo, ApplicationDate, ApplicationRemarks);
                }
                return this.SendHtmlFormattedEmail("Directorate of Tourism Services KPK", body, ToEmail);

            }
            catch
            {
                return "Fail";
                // return EmailStatus;
            }
        }
        private string CreateEmailBodyForInspection(string userName, string BusinessName, string BusinessType, string ApplicationNo, string FileNo, string ApplicationDate, string DespositeSlip,string ApplicationRemarks)
        {

            string body = string.Empty;
            //using streamreader for reading my htmltemplate   

            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/ApplicationRecordEmail.html")))
            {

                body = reader.ReadToEnd();

            }

            body = body.Replace("{UserName}", userName); //replacing the required things  
            body = body.Replace("{BusinessType}", BusinessType);
            body = body.Replace("{BusinessName}", BusinessName);
            body = body.Replace("{ApplicationNumber}", ApplicationNo); //replacing the required things  
            body = body.Replace("{FileNo}", FileNo);
            body = body.Replace("{ApplicationDate}", ApplicationDate);
            body = body.Replace("{DepositSlip}", DespositeSlip);
            body = body.Replace("{OperatorRemarks}", ApplicationRemarks);
            return body;

        }
        private string CreateEmailBodyForInspector(string userName, string Inspector, string InsepctionDateTime, string ApplicationNo,  string ApplicationDate,  string ApplicationRemarks)
        {

            string body = string.Empty;
            //using streamreader for reading my htmltemplate   

            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/InspectorEmail.html")))
            {

                body = reader.ReadToEnd();

            }

            body = body.Replace("{UserName}", userName); //replacing the required things  
            body = body.Replace("{InspectorName}", Inspector);
            body = body.Replace("{VisitDateTime}", InsepctionDateTime);
            body = body.Replace("{ApplicationNumber}", ApplicationNo); //replacing the required things  
          
            body = body.Replace("{ApplicationDate}", ApplicationDate);
    
            body = body.Replace("{OperatorRemarks}", ApplicationRemarks);
            return body;

        }
        private string CreateEmailBodyForRecommended(string userName, string LicenceNo, string InsepctionDate, string ApplicationNo, string ApplicationDate)
        {

            string body = string.Empty;
            //using streamreader for reading my htmltemplate   

            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/RecommendedEmail.html")))
            {

                body = reader.ReadToEnd();

            }

            body = body.Replace("{UserName}", userName); //replacing the required things  
            body = body.Replace("{licenseNo}", LicenceNo);
            body = body.Replace("{InspectionDate}", InsepctionDate);
            body = body.Replace("{ApplicationNumber}", ApplicationNo); //replacing the required things  

            body = body.Replace("{ApplicationDate}", ApplicationDate);

            return body;

        }
        private string CreateEmailBodyForNonRecommended(string userName, string LicenceNo, string InsepctionDate, string ApplicationNo, string ApplicationDate,string Remarks)
        {

            string body = string.Empty;
            //using streamreader for reading my htmltemplate   

            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/NonRecommendedEmail.html")))
            {

                body = reader.ReadToEnd();

            }

            body = body.Replace("{UserName}", userName); //replacing the required things  
            body = body.Replace("{InspectionDate}", InsepctionDate);
            body = body.Replace("{ApplicationNumber}", ApplicationNo); //replacing the required things  

            body = body.Replace("{ApplicationDate}", ApplicationDate);

            body = body.Replace("{DirectorRemarks}", Remarks);
            return body;

        }
        private string CreateEmailBodyForFinding(string userName, string BusinessName, string BusinessType, string ApplicationNo, string FileNo, string ApplicationDate, string DespositeSlip, string ApplicationRemarks)
        {

            string body = string.Empty;
            //using streamreader for reading my htmltemplate   

            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/FindingsEmail.html")))
            {

                body = reader.ReadToEnd();

            }

            body = body.Replace("{UserName}", userName); //replacing the required things  
            body = body.Replace("{ApplicationNumber}", ApplicationNo); //replacing the required things  
            body = body.Replace("{ApplicationDate}", ApplicationDate);
            body = body.Replace("{OperatorRemarks}", ApplicationRemarks);
            return body;

        }
        private string SendHtmlFormattedEmail(string subject, string body,string ToEmail)
        {

            using (MailMessage mailMessage = new MailMessage())
            {

                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);

                mailMessage.Subject = subject;

                mailMessage.Body = body;

                mailMessage.IsBodyHtml = true;

                mailMessage.To.Add(new MailAddress(ToEmail));

                SmtpClient smtp = new SmtpClient();

                smtp.Host = ConfigurationManager.AppSettings["Host"];

                smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);

                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();

                NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"]; //reading from web.config  

                NetworkCred.Password = ConfigurationManager.AppSettings["Password"]; //reading from web.config  

                smtp.UseDefaultCredentials = true;

                smtp.Credentials = NetworkCred;

                smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]); //reading from web.config  
                
                try
                {
                    smtp.Send(mailMessage);
                    return "Success";
                }
                catch
                {
                    return "Fail";
                }

            }

        }
       
    }
    public class DataKeeper
    {
        public string name { get; set; }
        public string value { get; set; }

    }
    public class ArrayDetails
    {
        public string Parm1 { get; set; }
        public string Parm2 { get; set; }
        public string Parm3 { get; set; }
        public string Parm4 { get; set; }
        public string Parm5 { get; set; }
        public string Parm6 { get; set; }
        public string Parm7 { get; set; }
    }
}