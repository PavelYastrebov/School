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
using System.Data;
using MahApps.Metro.Controls;
using System.Windows.Forms;

namespace School_Progect
{
    /// <summary>
    /// Логика взаимодействия для ParentsWindow.xaml
    /// </summary>
    public partial class ParentsWindow : MetroWindow
    {
        string id, name;
        string id_teacher, name_teacher;
        string id_cols;
        string id_subject;

       public DataTable student = new DataTable();
        public ParentsWindow(DataTable dt)
        {
            name = dt.Rows[0].ItemArray[2].ToString();
            id = dt.Rows[0].ItemArray[0].ToString();
            InitializeComponent();
            nameLabel.Content = name;
            student = dt.Copy();
            GetComments();
            GetSubjects();
            GetTeacher();
            GetPresents();
            this.dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
        }
 /////////////
 ////////////
 //даты заносить в формате ДД.ММ.ГГГ, например 09.12.2014 - катит, а 9.12.2014 - не катит! 
 /////////////
 ////////////
        private void buttonGetTT_click(object sender, RoutedEventArgs e)
        {
                DataSet ds1 = SQL.DoSQL("select distinct lesson.time, subject.name, lesson.HomeTask from subject, lesson where subject.id = lesson.id_subject and lesson.id_class = '" + student.Rows[0].ItemArray[1] + "' and date='" + calendarTT.SelectedDate.ToString().Substring(0,10) + "'");
                dataGridView1.Refresh();
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.DataSource = ds1;
                dataGridView1.DataMember = " ";
                dataGridView1.Columns[0].Width = 50;
        }

        void GetComments()
        {
            DataSet ds2 = SQL.DoSQL("select distinct comment.date, comment.comment, teacher.name from comment, teacher where comment.id_teacher=teacher.id and id_student = "+id+"");
            dataGridView2.Refresh();
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.DataSource = ds2;
            dataGridView2.DataMember = " ";
            dataGridView2.Columns[0].Width = 150;
            dataGridView2.Columns[1].Width = 450;
            dataGridView2.Columns[2].Width = 163;
        }

        void GetSubjects()
        {
            DataSet ds2 = SQL.DoSQL("select distinct id as № , name from subject where id_class= (select class.id from class, student where class.id = student.id_class and student.id= "+id+")");
            
            dataGridViewSubjects.Refresh();
            dataGridViewSubjects.RowHeadersVisible = false;
            dataGridViewSubjects.DataSource = ds2;
            dataGridViewSubjects.DataMember = " ";
            dataGridViewSubjects.Columns[0].Width = 50;
            dataGridViewSubjects.Columns[1].Width = 135;

            dataGridViewS.Refresh();
            dataGridViewS.RowHeadersVisible = false;
            dataGridViewS.DataSource = ds2;
            dataGridViewS.DataMember = " ";
            dataGridViewS.Columns[0].Width = 50;
            dataGridViewS.Columns[1].Width = 135;

        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            id_subject = dataGridViewSubjects[0, dataGridViewSubjects.CurrentRow.Index].Value.ToString();
            DataSet ds2 = SQL.DoSQL("select lesson.date, stud_les.mark from stud_les, lesson where stud_les.id_lesson = lesson.id and stud_les.id_student = " + id + " and lesson.id_subject = " + id_subject + " and stud_les.mark is not NULL");
            dataGridViewMarks.Refresh();
            dataGridViewMarks.RowHeadersVisible = false;
            dataGridViewMarks.DataSource = ds2;
            dataGridViewMarks.DataMember = " ";
            dataGridViewMarks.Columns[0].Width = 300;
            dataGridViewMarks.Columns[1].Width = 270;
        }


        void GetTeacher()
        {
            DataSet ds2 = SQL.DoSQL("select id as №, name from Teacher ");

            dataGridViewTeach.Refresh();
            dataGridViewTeach.RowHeadersVisible = false;
            dataGridViewTeach.DataSource = ds2;
            dataGridViewTeach.DataMember = " ";
            dataGridViewTeach.Columns[0].Width = 40;
            dataGridViewTeach.Columns[1].Width = 150;

        }




        private void Inform(object sender, RoutedEventArgs e)
        {
            id_teacher = dataGridViewTeach[0, dataGridViewTeach.CurrentRow.Index].Value.ToString();
            name_teacher = dataGridViewTeach[1, dataGridViewTeach.CurrentRow.Index].Value.ToString();
            DataSet ds2 = SQL.DoSQL("select *  from Teacher where id = {0}",id_teacher);
            lbTeaName.Content = ds2.Tables[0].Rows[0][2].ToString();
            lbTeaTel.Content = ds2.Tables[0].Rows[0][4].ToString();
            lbTeaAddress.Content = ds2.Tables[0].Rows[0][3].ToString();
            lbTeaEmail.Content = ds2.Tables[0].Rows[0][5].ToString();

            DataSet ds3 = SQL.DoSQL("SELECT AVG(mark) AS mark FROM RatingTeachers where id_teacher = {0}", id_teacher);
            lbTeaRat.Content = ds3.Tables[0].Rows[0][0].ToString();

            DisplayComments();
        }


        void GetPresents()
        {
            DataSet ds2 = SQL.DoSQL("select distinct id as № , name from subject where id_class= (select class.id from class, student where class.id = student.id_class and student.id= " + id + ")");

            dataGridViewSubjects2.Refresh();
            dataGridViewSubjects2.RowHeadersVisible = false;
            dataGridViewSubjects2.DataSource = ds2;
            dataGridViewSubjects2.DataMember = " ";
            dataGridViewSubjects2.Columns[0].Width = 50;
            dataGridViewSubjects2.Columns[1].Width = 135;

        }




        private void Cols(object sender, RoutedEventArgs e)
        {
            id_subject = dataGridViewSubjects2[0, dataGridViewSubjects2.CurrentRow.Index].Value.ToString();
            string minus = "m";
            DataSet ds2 = SQL.DoSQL("select lesson.date, stud_les.presence from stud_les, Lesson where stud_les.id_lesson = lesson.id and stud_les.id_student = " + id + " and lesson.id_subject = " + id_subject);// + " and stud_les.presence = " + minus);
            dataGridViewPresentses.Refresh();
            dataGridViewPresentses.RowHeadersVisible = false;
            dataGridViewPresentses.DataSource = ds2;
            dataGridViewPresentses.DataMember = " ";
            dataGridViewPresentses.Columns[0].Width = 300;
            dataGridViewPresentses.Columns[1].Width = 270;
        }


        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGridView1_CellValidating(object sender, System.Windows.Forms.DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode)
                dataGridView1.CancelEdit();
        }
        void updateFood()
        {
            DataTable dt = new DataTable();
            dt = SQL.DoSQLDT("select distinct Food.name from Food,Menu where Food.id = Menu.id_food and Menu.date = '{0}' and Food.type = 'Первое'", calendarFood.SelectedDate.ToString().Substring(0, 10));
            if (dt.Rows.Count != 0)
                labelFirstDishValue.Content = dt.Rows[0].ItemArray[0].ToString();
            else labelFirstDishValue.Content = "-";
            dt = SQL.DoSQLDT("select distinct Food.name from Food,Menu where Food.id = Menu.id_food and Menu.date = '{0}' and Food.type = 'Второе'", calendarFood.SelectedDate.ToString().Substring(0, 10));
            if (dt.Rows.Count != 0)
                labelTwiseDishValue.Content = dt.Rows[0].ItemArray[0].ToString();
            else labelTwiseDishValue.Content = "-";
            dt = SQL.DoSQLDT("select distinct Food.name from Food,Menu where Food.id = Menu.id_food and Menu.date = '{0}' and Food.type = 'Десерт'", calendarFood.SelectedDate.ToString().Substring(0, 10));
            if (dt.Rows.Count != 0)
                labelDesertValue.Content = dt.Rows[0].ItemArray[0].ToString();
            else labelDesertValue.Content = "-";
            dt = SQL.DoSQLDT("select distinct Food.name from Food,Menu where Food.id = Menu.id_food and Menu.date = '{0}' and Food.type = 'Напиток'", calendarFood.SelectedDate.ToString().Substring(0, 10));
            if (dt.Rows.Count != 0)
                labelDrinkValue.Content = dt.Rows[0].ItemArray[0].ToString();
            else labelDrinkValue.Content = "-";

            comboBoxFirstDish.Items.Clear();
            comboBoxTwiseDish.Items.Clear();
            comboBoxDesert.Items.Clear();
            comboBoxDrink.Items.Clear();
            comboBoxFoodType.Items.Clear();
            dt = SQL.DoSQLDT("select distinct Food.name from Food where Food.type = 'Первое'");
            if (dt.Rows.Count != 0)
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBoxFirstDish.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                }
            if (labelFirstDishValue.Content == "-")
                comboBoxFirstDish.SelectedIndex = 0;
            else
                comboBoxFirstDish.SelectedItem = labelFirstDishValue.Content;
            dt = SQL.DoSQLDT("select distinct Food.name from Food where Food.type = 'Второе'");
            if (dt.Rows.Count != 0)
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBoxTwiseDish.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                }
            if (labelTwiseDishValue.Content == "-")
                comboBoxTwiseDish.SelectedIndex = 0;
            else
                comboBoxTwiseDish.SelectedItem = labelTwiseDishValue.Content;
            dt = SQL.DoSQLDT("select distinct Food.name from Food where Food.type = 'Десерт'");
            if (dt.Rows.Count != 0)
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBoxDesert.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                }
            if (labelDesertValue.Content == "-")
                comboBoxDesert.SelectedIndex = 0;
            else
                comboBoxDesert.SelectedItem = labelDesertValue.Content;
            dt = SQL.DoSQLDT("select distinct Food.name from Food where Food.type = 'Напиток'");
            if (dt.Rows.Count != 0)
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBoxDrink.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                }
            if (labelDrinkValue.Content == "-")
                comboBoxDrink.SelectedIndex = 0;
            else
                comboBoxDrink.SelectedItem = labelDrinkValue.Content;


            dt = SQL.DoSQLDT("select distinct Food.type from Food");
            if (dt.Rows.Count != 0)
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBoxFoodType.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                }
            comboBoxFoodType.SelectedIndex = 0;
        }

        private void TabItem_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            calendarFood.SelectedDate = DateTime.Today;
            updateFood();
        }


        private void buttonAddFood_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SQL.DoSQL("insert into Food(type,name) values ('{0}','{1}')", comboBoxFoodType.SelectedItem.ToString(), textBoxFoodName.Text);
                updateFood();
                new Message("Готово!").ShowDialog();
            }
            catch (NullReferenceException)
            {

            }
        }

        private void buttonSaveSuggestion_Click(object sender, RoutedEventArgs e)
        {

            if (comboBoxFirstDish.SelectedItem != null)
            {
                SQL.DoSQLDT("insert into FoodSuggestion(id_student,id_food,date) values({0},(select id from Food where name = '{1}'),'{2}')", student.Rows[0].ItemArray[1], comboBoxFirstDish.SelectedItem.ToString(), calendarFood.SelectedDate.ToString().Substring(0, 10));
            }
            if (comboBoxTwiseDish.SelectedItem != null)
            {
                SQL.DoSQLDT("insert into FoodSuggestion(id_student,id_food,date) values({0},(select id from Food where name = '{1}'),'{2}')", student.Rows[0].ItemArray[1], comboBoxTwiseDish.SelectedItem.ToString(), calendarFood.SelectedDate.ToString().Substring(0, 10));

            }
            if (comboBoxDesert.SelectedItem != null)
            {
                SQL.DoSQLDT("insert into FoodSuggestion(id_student,id_food,date) values({0},(select id from Food where name = '{1}'),'{2}')", student.Rows[0].ItemArray[1], comboBoxDesert.SelectedItem.ToString(), calendarFood.SelectedDate.ToString().Substring(0, 10));

            }
            if (comboBoxDrink.SelectedItem != null)
            {
                SQL.DoSQLDT("insert into FoodSuggestion(id_student,id_food,date) values({0},(select id from Food where name = '{1}'),'{2}')", student.Rows[0].ItemArray[1], comboBoxDrink.SelectedItem.ToString(), calendarFood.SelectedDate.ToString().Substring(0, 10));

            }
            else
            {
                new Message("Не выбраны поля").ShowDialog();
            }
        }

        private void calendarFood_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            updateFood();
        }

        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {
            calendarFood.SelectedDate = DateTime.Today;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string s1 = dataGridViewS[0, dataGridViewS.CurrentRow.Index].Value.ToString();
            DataSet ds2 = SQL.DoSQL("select date, theme from theme where id_subject = {0}",s1);
            dataGridViewT.Refresh();
            dataGridViewT.RowHeadersVisible = false;
            dataGridViewT.DataSource = ds2;
            dataGridViewT.DataMember = " ";
            dataGridViewT.Columns[0].Width = 100;
            dataGridViewT.Columns[1].Width = 470;
        }

        private void ButtonRating_Click(object sender, RoutedEventArgs e)
        {
            if (name_teacher == null||id_teacher==null)
            {
                new Message("Не выбран учитель").ShowDialog();
                return;
            }
            var win = new Rating(id_teacher, name_teacher);
            win.ShowDialog();
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
            events = SQL.DoSQLDT("select * from RatingTeachers where id_teacher = {0} and comment is not NULL",id_teacher);
        }
        void DisplayEvent()
        {
            try
            {
                textContent.Text = events.Rows[counter].ItemArray[3].ToString();
                CheckNext();
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
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
        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {
            UpdateEvents();
            GetCountMax();
            DisplayEvent();
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
