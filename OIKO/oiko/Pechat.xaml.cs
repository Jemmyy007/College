using System;
using System.Collections.Generic;
using System.Data.OleDb;
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

namespace oiko
{
    /// <summary>
    /// Логика взаимодействия для Pechat.xaml
    /// </summary>
    public partial class Pechat : Window
    {
        OleDbCommand cmd1, cmd2, cmd3, cmd4, cmd5, cmd6;
        OleDbConnection con;
        public Pechat()
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Database oiko.accdb");
            con.Open();

            InitializeComponent();

            string count1 = "SELECT COUNT(*) FROM uchet";
            string count2 = "SELECT COUNT(*) FROM uchet WHERE Статус = 'На складе'";
            string count3 = "SELECT COUNT(*) FROM uchet WHERE Статус = 'Используется'";
            string count4 = "SELECT COUNT(*) FROM uchet WHERE Статус = 'Неисправно'";

            cmd1 = new OleDbCommand(count1, con);
            cmd2 = new OleDbCommand(count2, con);
            cmd3 = new OleDbCommand(count3, con);
            cmd4 = new OleDbCommand(count4, con);

            string all = cmd1.ExecuteScalar().ToString();
            string sklad = cmd2.ExecuteScalar().ToString();
            string use = cmd3.ExecuteScalar().ToString();
            string dontWork = cmd4.ExecuteScalar().ToString();
            string date = DateTime.Now.ToShortDateString();

            lall.Content += all;
            lsklad.Content += sklad;
            luse.Content += use;
            ldontWork.Content += dontWork;
            lDate.Content += date;

            con.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string date = DateTime.Today.ToString("G");
            PrintDialog pr = new PrintDialog();
            if (pr.ShowDialog() == true)
            {
                pr.PrintVisual(logoContainer1, $"{date}");
            }
        }
    }
}
