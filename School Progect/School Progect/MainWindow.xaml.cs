using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
//

namespace School_Progect
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e){}
        

        private void Label_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            
        }
        DataSet connectToDataBase(string s)
        {
            MySqlDataAdapter da;
            DataSet ds = null;
            string sTable = " ";
            string connectionString = Properties.Resources.conString;
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                da = new MySqlDataAdapter(s, conn);
                ds = new DataSet();
                da.Fill(ds, sTable);
                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable dt = ParentLogIn(mailBox.Text);
                if (dt.Rows != null)
                {
                    var win = new ParentsWindow(dt);
                    this.Close();
                    win.ShowDialog();
                }
            }
            catch (NullReferenceException)
            {
                return;
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }
        public static bool EmailIsValid(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
        DataTable ParentLogIn(string email)
        {
            if (EmailIsValid(email))
            {
                var dt = SQL.DoSQLDT("select * from Student where  email = '{0}'", email);
                if (dt.Rows.Count == 0)
                {
                    new Message("Такой аккаунт не существует!").ShowDialog();
                return null;
                }
                else
                {
                    return dt;
                }
            }
            else new Message("Почта введена некорректно!").ShowDialog();
            return null;
        }

        private void Label_MouseDoubleClick_2(object sender, MouseButtonEventArgs e)
        {

        }

        private void tButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataSet id = connectToDataBase("Select id from Teacher where `email` = '" + mailBox1.Text + "'");
                object value = null;
                try
                {
                    value = id.Tables[0].Rows[0][0];
                }
                catch (IndexOutOfRangeException)
                {
                    new Message("Учитель с таким электронным адресом не зарегистрирован").ShowDialog();
                    return;
                }
                var win = new TeacherWindow(Convert.ToInt32(value));
                win.ShowDialog();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        private void zButton_Click(object sender, RoutedEventArgs e)
        {
            var win = new directorOfStudiesWindow();
            win.ShowDialog();
            this.Close();
        }

        private void aButton_Click(object sender, RoutedEventArgs e)
        {
            if (aTextBox.Text == "1111")
            {
                var win = new admin();
                win.ShowDialog();
            }
            else new Message("Введите пароль").ShowDialog();
        }

        private void aTextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void aTextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            
        }

        private void aTextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
