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

namespace School_Progect
{
    /// <summary>
    /// Логика взаимодействия для directorOfStudiesWindow.xaml
    /// </summary>
    public partial class directorOfStudiesWindow : MetroWindow
    {
        public directorOfStudiesWindow()
        {
            InitializeComponent();
            GetClasses();
            GetSubjects();
            calendarFood.SelectedDate = DateTime.Today;
            updateFood();
        }

        void GetClasses()
        {
            DataSet ds2 = SQL.DoSQL("select id as №, number from class");
            dataGridView1.Refresh();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DataSource = ds2;
            dataGridView1.DataMember = " ";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 135;

        }

        void GetSubjects()
        {
            DataSet ds2 = SQL.DoSQL("select id as №, name from subject");
            dataGridView2.Refresh();
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.DataSource = ds2;
            dataGridView2.DataMember = " ";
            dataGridView2.Columns[0].Width = 50;
            dataGridView2.Columns[1].Width = 135;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbDate.Text == String.Empty || tbTime.Text == String.Empty)
            {
                new Message("Все поля должны быть заполнены").ShowDialog();
                return;
            }
            try
            {
                SQL.DoSQL("insert into lesson (id_class, id_subject, date, time) values (N'{0}',N'{1}',N'{2}',N'{3}')",
                    dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString(), dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString(), tbDate.Text, tbTime.Text);
                new Message("Урок добавлен").ShowDialog();
            }
            catch 
            {
                new Message("неудача").ShowDialog();
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        void updateFood()
        {
            DataTable dt = new DataTable();
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
            dt = SQL.DoSQLDT("select distinct Food.name from Food,Menu where Food.id = Menu.id_food and Menu.date = '{0}' and Food.type = 'Первое'", calendarFood.SelectedDate.ToString().Substring(0, 10));
            if (dt.Rows.Count == 0)
                comboBoxFirstDish.SelectedIndex = 0;
            else
            {
                comboBoxFirstDish.SelectedItem = dt.Rows[0].ItemArray[0].ToString();
                MessageBox.Show(dt.Rows[0].ItemArray[0].ToString());
            }
            dt = SQL.DoSQLDT("select distinct Food.name from Food where Food.type = 'Второе'");
            if (dt.Rows.Count != 0)
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBoxTwiseDish.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                }
            dt = SQL.DoSQLDT("select distinct Food.name from Food,Menu where Food.id = Menu.id_food and Menu.date = '{0}' and Food.type = 'Второе'", calendarFood.SelectedDate.ToString().Substring(0, 10));
            if (dt.Rows.Count == 0)
                comboBoxTwiseDish.SelectedIndex = 0;
            else
                comboBoxTwiseDish.SelectedItem = dt.Rows[0].ItemArray[0].ToString();
            dt = SQL.DoSQLDT("select distinct Food.name from Food where Food.type = 'Десерт'");
            if (dt.Rows.Count != 0)
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBoxDesert.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                }
            dt = SQL.DoSQLDT("select distinct Food.name from Food,Menu where Food.id = Menu.id_food and Menu.date = '{0}' and Food.type = 'Десерт'", calendarFood.SelectedDate.ToString().Substring(0, 10));
            if (dt.Rows.Count == 0)
                comboBoxDesert.SelectedIndex = 0;
            else
                comboBoxDesert.SelectedItem = dt.Rows[0].ItemArray[0].ToString();
            dt = SQL.DoSQLDT("select distinct Food.name from Food where Food.type = 'Напиток'");
            if (dt.Rows.Count != 0)
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBoxDrink.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                }
            dt = SQL.DoSQLDT("select distinct Food.name from Food,Menu where Food.id = Menu.id_food and Menu.date = '{0}' and Food.type = 'Напиток'", calendarFood.SelectedDate.ToString().Substring(0, 10));
            if (dt.Rows.Count == 0)
                comboBoxDrink.SelectedIndex = 0;
            else
                comboBoxDrink.SelectedItem = dt.Rows[0].ItemArray[0].ToString();


            dt = SQL.DoSQLDT("select distinct Food.type from Food");
            if (dt.Rows.Count != 0)
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBoxFoodType.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                }
            comboBoxFoodType.SelectedIndex = 0;
        }

        private void calendarFood_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            updateFood();
            getAdv("Первое");
        }

        private void buttonAddFood_Click(object sender, RoutedEventArgs e)
        {
            SQL.DoSQL("insert into Food(type,name) values ('{0}','{1}')", comboBoxFoodType.SelectedItem.ToString(), textBoxFoodName.Text);
            updateFood();
            new Message("Готово!").ShowDialog();
        }

        private void buttonSaveSuggestion_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxFirstDish.SelectedItem != null)
            {
                SQL.DoSQLDT("insert into Menu(id_food,date) values((select id from Food where name = '{0}'),'{1}')", comboBoxFirstDish.SelectedItem.ToString(), calendarFood.SelectedDate.ToString().Substring(0, 10));
            }
            if (comboBoxTwiseDish.SelectedItem != null)
            {
                SQL.DoSQLDT("insert into Menu(id_food,date) values((select id from Food where name = '{0}'),'{1}')", comboBoxTwiseDish.SelectedItem.ToString(), calendarFood.SelectedDate.ToString().Substring(0, 10));

            }
            if (comboBoxDesert.SelectedItem != null)
            {
                SQL.DoSQLDT("insert into Menu(id_food,date) values((select id from Food where name = '{0}'),'{1}')", comboBoxDesert.SelectedItem.ToString(), calendarFood.SelectedDate.ToString().Substring(0, 10));

            }
            if (comboBoxDrink.SelectedItem != null)
            {
                SQL.DoSQLDT("insert into Menu(id_food,date) values((select id from Food where name = '{0}'),'{1}')", comboBoxDrink.SelectedItem.ToString(), calendarFood.SelectedDate.ToString().Substring(0, 10));

            }
            else
            {
                new Message("Не выбраны поля").ShowDialog();
            }

        }
        void getAdv(string type)
        {
            DataSet ds1 = SQL.DoSQL("select distinct Student.parent_name, Food.name from Student, Food, FoodSuggestion where Student.id = FoodSuggestion.id_student and Food.id = FoodSuggestion.id_food and FoodSuggestion.date = '{0}' and Food.type = '{1}'", calendarFood.SelectedDate.ToString().Substring(0, 10), type);
            dataGridView3.Refresh();
            dataGridView3.RowHeadersVisible = false;
            dataGridView3.DataSource = ds1;
            dataGridView3.DataMember = " ";
            dataGridView3.Columns[0].Width = 139;
            dataGridView3.Columns[1].Width = 139;
        }

        private void buttonFirst_Click(object sender, RoutedEventArgs e)
        {
            getAdv("Первое");
        }

        private void buttonSecond_Click(object sender, RoutedEventArgs e)
        {
            getAdv("Второе");
        }

        private void buttonDesert_Click(object sender, RoutedEventArgs e)
        {
            getAdv("Десерт");
        }

        private void buttonDrink_Click(object sender, RoutedEventArgs e)
        {
            getAdv("Напиток");
        }
    }
}
