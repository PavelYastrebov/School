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
using MahApps.Metro.Controls;


namespace School_Progect
{
    /// <summary>
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent : MetroWindow
    {
        public AddEvent()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxLabel.Text == "" || textBoxContent.Text == "" || datePickerEnd.SelectedDate == null)
                MessageBox.Show("Не все поля заполнены!");
            else
                try
                {
                    SQL.DoSQL("insert into Advertisement (id_teacher,dateEnd,label,content) values (1,N'{0}',N'{1}',N'{2}')", datePickerEnd.SelectedDate.ToString().Substring(0, 10), textBoxLabel.Text, textBoxContent.Text);
                }
                catch
                {
                    MessageBox.Show("неудача");
                }
                finally
                {
                    MessageBox.Show("Добавлено");
                    this.Close();
                }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = datePickerEnd.SelectedDate.ToString();
            MessageBox.Show(s);
        }
    }
}
