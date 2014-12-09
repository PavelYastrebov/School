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
    /// Логика взаимодействия для TeacherWindow.xaml
    /// </summary>
    public partial class TeacherWindow : MetroWindow
    {
        string sub, clas, date;
        DataSet ds;
        int techid;
        public TeacherWindow(int id)
        {
            InitializeComponent();
            techid = id;
            ds = connectToDataBase("select * from teacher where `id` = " + id);
            nameLabel.Content = ds.Tables[0].Rows[0][2];
            fillCombobox();
            fillSection();
            DisplayComments();
            

        }

        void fillContacts()
        {
            DataSet contacts = connectToDataBase("select id, name from student where id_class = (select id from class where number = '"+clas+"')");
            dataGridViewContacts.Refresh();
            dataGridViewContacts.RowHeadersVisible = false;
            dataGridViewContacts.DataSource = contacts;
            dataGridViewContacts.DataMember = " ";
            dataGridViewContacts.Columns[0].Width = 50;
            dataGridViewContacts.Columns[1].Width = 265;
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
        void fillCombobox()
        {
            DataSet dsSubjects = connectToDataBase("select * from subject where id_teacher =" + techid);
            for (int i = 0; i < dsSubjects.Tables[0].Rows.Count; i++)
            {
                cbSubj.Items.Add(dsSubjects.Tables[0].Rows[i][3].ToString());
            }
            DataSet dsClasses = connectToDataBase("select class.id, class.number from class, subject where class.id = subject.id_class and id_teacher =" + techid);
            for (int i = 0; i < dsClasses.Tables[0].Rows.Count; i++)
            {
                cbClass.Items.Add(dsClasses.Tables[0].Rows[i][1].ToString());
            }
            DataSet dsStudents = connectToDataBase("select name from student");
            for (int i = 0; i < dsStudents.Tables[0].Rows.Count; i++)
            {
                cbStudent.Items.Add(dsStudents.Tables[0].Rows[i][0].ToString());
            }
        }
        void fillSection()
        {
            DataSet sections = connectToDataBase("select name, days, time from section");
            dataGridViewSection.Refresh();
            dataGridViewSection.RowHeadersVisible = false;
            dataGridViewSection.DataSource = sections;
            dataGridViewSection.DataMember = " ";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (cbClass.Text == String.Empty || cbSubj.Text == String.Empty)
            {
                new Message("Не все поля заполнены").ShowDialog();
                return;
            }
            sub = cbSubj.Text;
            clas = cbClass.Text;
            lbclass.Content = clas;
            lbsub.Content = sub;

            DataSet ds2 = connectToDataBase("select lesson.date from lesson, class, subject where lesson.id_class = class.id and lesson.id_subject = subject.id and class.number = '" + clas + "' and subject.name = '" + sub + "'");
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                cbDate.Items.Add(ds2.Tables[0].Rows[i][0].ToString());
                cbDate2.Items.Add(ds2.Tables[0].Rows[i][0].ToString());
            }
            fillContacts();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (cbClass.Text != String.Empty && cbSubj.Text != String.Empty)
            {
                DataSet ds1 = connectToDataBase("select distinct student.id, student.name, stud_les.presence, stud_les.mark from student, stud_les, lesson where lesson.id_subject = (select id from subject where name ='" + sub + "') and student.id_class = (select id from class where number='" + clas + "') and date='" + cbDate.Text + "'");
                dataGridView1.Refresh();
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.DataSource = ds1;
                dataGridView1.DataMember = " ";
                dataGridView1.Columns[0].Width = 50;
            }
            else new Message("Выберите класс и предмет").ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                string p = dataGridView1[2, i].Value.ToString();
                string m = dataGridView1[3, i].Value.ToString();
                if (p == String.Empty) p = "NULL";
                if (m == String.Empty) m = "NULL";
                DataSet ds1 = connectToDataBase("update stud_les set presence = '" +
                    p + "', mark = '" +
                    m + "' where id = '" +
                    dataGridView1[0, i].Value.ToString() + "'");

                //System.Windows.Forms.MessageBox.Show(dataGridView1[2, i].Value.ToString());
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (cbStudent.Text == String.Empty)
            {
                new Message("Выберите ученика").ShowDialog();
                return;
            }
            if (tbComm.Text == String.Empty)
            {
                new Message("Введите комментарий").ShowDialog();
                return;
            }
            DataSet dsstu = connectToDataBase("select id from student where name = '" + cbStudent.Text + "'");
            string stid = dsstu.Tables[0].Rows[0][0].ToString();
            string date = DateTime.Now.Date.ToString("d");

            DataSet ds1 = connectToDataBase("INSERT INTO `SchoolDB`.`Comment` (`id` ,`id_teacher` ,`id_student` ,`date` ,`comment`) VALUES (NULL,'" + techid + "', '" + stid + "', '" + date + "', '" + tbComm.Text + "');");

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (tb1.Text == String.Empty || tb2.Text == String.Empty || tb3.Text == String.Empty)
            {
                new Message("Нужно заполнить все поля").ShowDialog();
                return;
            }
            DataSet ds1 = connectToDataBase("INSERT INTO `SchoolDB`.`Section` (`id` ,`id_teacher` ,`name` ,`days` ,`time`) VALUES (NULL,'" + techid + "', '" + tb1.Text + "', '" + tb2.Text + "', '" + tb3.Text + "');");
            fillSection();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var win = new AddEvent();
            win.ShowDialog();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            var win = new Events();
            win.ShowDialog();
        }


        private void Button_Choose_HT(object sender, RoutedEventArgs e)
        {

            date = cbDate2.Text;
            DataSet ds1 = connectToDataBase("select HomeTask from lesson, class, subject where lesson.id_class = class.id and lesson.id_subject = subject.id and class.number = '" + clas + "' and subject.name = '" + sub + "' and lesson.date = '" + date + "'");
            dataGridViewHomeTask.Refresh();
            dataGridViewHomeTask.RowHeadersVisible = false;
            dataGridViewHomeTask.DataSource = ds1;
            dataGridViewHomeTask.DataMember = " ";
            dataGridViewHomeTask.Columns[0].Width = 200;
        }

        private void Button_Save_HT(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataGridViewHomeTask.RowCount; i++)
            {

                string m = dataGridViewHomeTask[0, 0].Value.ToString();
                if (m == String.Empty) m = "NULL";
                DataSet ds1 = connectToDataBase(
                    "UPDATE Lesson, Class, Subject SET Lesson.HomeTask = '" + m + "'where lesson.id_class = class.id and lesson.id_subject = subject.id and class.number = '" + clas + "' and subject.name = '" + sub + "' and lesson.date = '" + date + "'");


            }
        }
        private void Label_MouseDoubleClick_2(object sender, MouseButtonEventArgs e)
        {
            var window = new MarksSending();
            window.ShowDialog();
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            sub = cbSubj.Text;
            clas = cbClass.Text;
            MySqlDataAdapter da;
            System.Data.DataTable ds = null;
            string connectionString = Properties.Resources.conString;
            MySqlConnection conn = null;
            conn = new MySqlConnection(connectionString);
            conn.Open();
            da = new MySqlDataAdapter("select Student.name, stud_les.mark, stud_les.presence, lesson.date from stud_les, Student, lesson, class, subject where stud_les.id_student = Student.id and lesson.id_class = class.id and lesson.id_subject = subject.id and class.number = '" + clas + "' and subject.name = '" + sub + "'", conn);
            ds = new System.Data.DataTable();
            da.Fill(ds);
            conn.Close();
            DtToExcel.GetInExcel(ds, clas + " --- " + sub);
        }

        private void buttonContacts_Click(object sender, RoutedEventArgs e)
        {
            DataSet dsContacts = connectToDataBase("select * from student where id =" + dataGridViewContacts[0, dataGridViewContacts.CurrentRow.Index].Value.ToString());
            lbParentName.Content = dsContacts.Tables[0].Rows[0][5].ToString();
            lbParentPhone.Content = dsContacts.Tables[0].Rows[0][4].ToString();
            lbParentEmail.Content = dsContacts.Tables[0].Rows[0][3].ToString();
           
        }
        void DisplayComments()
        {
            UpdateEvents();
            DisplayEvent();
            GetCountMax();
        }

        DataTable events = new DataTable();
        int counter = 0;
        int countMax = 0;
        void UpdateEvents()
        {
            events = SQL.DoSQLDT("select * from RatingTeachers where id_teacher = {0} and comment is not NULL", techid);
        }
        void DisplayEvent()
        {
            textContent.Text = events.Rows[counter].ItemArray[3].ToString();
            CheckNext();
        }
        void CheckNext()
        {
            if (counter > 0) buttonLeft.IsEnabled = true;
            if (counter < countMax) buttonRight.IsEnabled = true;
            if (counter < 1) buttonLeft.IsEnabled = false;
            if (counter == countMax - 1) buttonRight.IsEnabled = false;

        }
        void GetCountMax()
        {
            countMax = events.Rows.Count;
        }

        private void buttonRight_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            DisplayEvent();
        }

        private void buttonLeft_Click(object sender, RoutedEventArgs e)
        {
            counter--;
            DisplayEvent();
        }
    }
}
