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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using MahApps.Metro.Controls;

namespace School_Progect
{
    /// <summary>
    /// Логика взаимодействия для Rating.xaml
    /// </summary>
    public partial class Rating : MetroWindow
    {
        string id = "0";
        public Rating(string id, string name)
        {
            InitializeComponent();
            this.id = id;
            lbrat.Content += "  " + name;
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
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mark = "";
            if (r1.IsChecked == true) mark = "1";
            if (r2.IsChecked == true) mark = "2"; 
            if (r3.IsChecked == true) mark = "3";
            if (r4.IsChecked == true) mark = "4";
            if (r5.IsChecked == true) mark = "5";
            if (r6.IsChecked == true) mark = "6";
            if (r7.IsChecked == true) mark = "7";
            if (r8.IsChecked == true) mark = "8";
            if (r9.IsChecked == true) mark = "9";
            if (r10.IsChecked == true) mark = "10";
            if (mark == "") 
            { 
                new Message("Оцените учителя по шкале от 1 до 10").ShowDialog(); 
                return; 
            }
            if (tbC1.Text == String.Empty)
            {
                DataSet ds1 = connectToDataBase("INSERT INTO `SchoolDB`.`RatingTeachers` (`id` ,`id_teacher` ,`mark` ,`comment`) VALUES (NULL,'" + id + "', '" + mark + "', NULL);");
                new Message("Отзыв сохранен").ShowDialog();
                this.Close();
            }
            else
            {
                DataSet ds1 = connectToDataBase("INSERT INTO `SchoolDB`.`RatingTeachers` (`id` ,`id_teacher` ,`mark` ,`comment`) VALUES (NULL,'" + id + "', '" + mark + "','" + tbC1.Text + "');");
                new Message("Отзыв сохранен").ShowDialog();
                this.Close();
            }
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
