using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Reflection;
using System.Text;

using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;

namespace School_Progect
{
    public class Mail
    {
        public static bool sendMail(string host, int port, string userName, string pswd, string fromAddress, string toAddress, string body, string subject, bool sslEnabled, string fileName)
        {
            var att = new Attachment(fileName);
            var msg = new MailMessage(new MailAddress(fromAddress), new MailAddress(toAddress))
            {
                Subject = subject,
                SubjectEncoding = Encoding.ASCII,
                Body = body,
                BodyEncoding = Encoding.ASCII,
                IsBodyHtml = false
            };

            msg.Attachments.Add(att);
            var client = new SmtpClient(host, port)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(userName, pswd),
                EnableSsl = sslEnabled
            };

            try
            {
                client.Send(msg);
                att.Dispose();
                msg.Dispose();
            }
            catch (SmtpException)
            {
                return false;
            }

            return true;
        }
    }
    public class DtToExcel
    {
        public static void GetInExcel(System.Data.DataTable dtin, string StrFileName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                foreach (DataColumn dataColumn in (InternalDataCollectionBase)dtin.Columns)
                    stringBuilder.Append(dataColumn.ColumnName + ",");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error :" + ex.Message);
            }
            DtToExcel.GenerateExcellSheet(((object)stringBuilder).ToString(), dtin, StrFileName);
        }

        private static void GenerateExcellSheet(string cols, System.Data.DataTable dt, string fname)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)new Microsoft.Office.Interop.Excel.Application() { Visible = false };
            _Workbook workbook = (_Workbook)application.Workbooks.Add((object)Missing.Value);
            _Worksheet worksheet = (_Worksheet)workbook.ActiveSheet;
            string[] strArray = cols.Split(new char[1] { ',' });
            for (int index = 0; index <= strArray.Length - 2; ++index)
            {
                int num = index + 1;
                worksheet.Cells[(object)1, (object)num] = (object)((object)strArray[index]).ToString();
            }
            for (int index1 = 0; index1 <= dt.Rows.Count - 1; ++index1)
            {
                for (int index2 = 0; index2 <= dt.Columns.Count - 1; ++index2)
                    worksheet.Cells[(object)(index1 + 2), (object)(index2 + 1)] = (object)dt.Rows[index1][index2].ToString();
            }
            worksheet.SaveAs(fname + ".xls", (object)Missing.Value, (object)Missing.Value, (object)Missing.Value, (object)Missing.Value, (object)Missing.Value, (object)Missing.Value, (object)Missing.Value, (object)Missing.Value, (object)Missing.Value);
            workbook.Close((object)Missing.Value, (object)Missing.Value, (object)Missing.Value);
            application.Quit();
        }

        public static System.Data.DataTable GetMarks()
        {
            MySqlDataAdapter da;
            System.Data.DataTable ds = null;
            string connectionString = Properties.Resources.conString;
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                da = new MySqlDataAdapter("SELECT Student.name,Subject.name,stud_les.mark,Theme.theme,Lesson.date FROM stud_les INNER JOIN Student ON stud_les.id_student = Student.id INNER JOIN Class ON Student.id_class = Class.id INNER JOIN Subject ON Subject.id_class = Class.id INNER JOIN Theme ON Theme.id_subject = Subject.id INNER JOIN Lesson ON stud_les.id_lesson = Lesson.id AND Lesson.id_subject = Subject.id AND Lesson.id_class = Class.id GROUP BY Student.name", conn);
                ds = new System.Data.DataTable();
                da.Fill(ds);
                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }
    }
    class AllSending
    {
    }
}
