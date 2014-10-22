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

namespace School_Progect
{
    /// <summary>
    /// Логика взаимодействия для admin.xaml
    /// </summary>
    public partial class admin : Window
    {
        public admin()
        {
            InitializeComponent();
            GetSchools();
        }

        void GetSchools()
        {
            DataSet ds = connectToDataBase(Properties.Resources.querySchools);
            dataGridView1.Refresh();
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = " ";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 135;

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

        private void bAddSchool_Click(object sender, RoutedEventArgs e)
        {
            if (tbAddress.Text == String.Empty || tbName.Text == String.Empty || tbNumber.Text == String.Empty || tbPhone.Text == String.Empty)
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }
            DataSet ds1 = connectToDataBase("INSERT INTO `SchoolDB`.`School` (`id` ,`number` ,`category` ,`city` ,`address` ,`phone`) VALUES (NULL,'" + tbNumber.Text + "', '" + tbName.Text + "', '" + cbCity.Text + "', '" + tbAddress.Text + "', '" + tbPhone.Text + "');");
            GetSchools();
        }
       
    }
}
