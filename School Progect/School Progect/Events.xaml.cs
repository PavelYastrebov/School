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
    /// Interaction logic for Events.xaml
    /// </summary>
    public partial class Events : MetroWindow
    {
        public Events()
        {
            InitializeComponent();
            UpdateEvents();
            DisplayEvent();
            GetCountMax();
        }

        DataTable events = new DataTable();
        int counter = 0;
        int countMax = 0;
        void UpdateEvents()
        {
            events = SQL.DoSQLDT("select * from Advertisement");
        }
        void DisplayEvent()
        {
            textLabel.Content = events.Rows[counter].ItemArray[3].ToString();
            textContent.Text = events.Rows[counter].ItemArray[4].ToString();
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
