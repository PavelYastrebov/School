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
    /// Логика взаимодействия для MarksSending.xaml
    /// </summary>
    public partial class MarksSending : MetroWindow
    {
        public MarksSending()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DtToExcel.GetInExcel(DtToExcel.GetMarks(), "TEST");
            if (Mail.sendMail("smtp.gmail.com", 25, "schoolprojectkture@gmail.com", "qwertypassword", "schoolprojectkture@gmail.com", "irina.kamenieva@gmail.com", "Test marks", "TEST MARKS", true, "C:/Users/" + Environment.UserName + "/Documents/TEST.xls"))
                new Message("Mail sent").ShowDialog();
            else
                new Message("Mail wasn't sent").ShowDialog();
        }
    }
}

    
