using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
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

namespace oiko
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        public MainWindow()
        {
            InitializeComponent();
           

            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string user = txtLogin.Text;
            string password = txtPassword.Password;

            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Database oiko.accdb");
            con.Open();

            string quary = $"SELECT post FROM user1 WHERE login = '{user}' AND pass = '{password}'";
            
            OleDbDataAdapter da = new OleDbDataAdapter(quary, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Неправильно введены данные");
            }
            else if (dt.Rows.Count == 1 && dt.Rows[0][0].ToString() == "Админ")
            {
                string quary1 = $"SELECT ФИО FROM user1 WHERE login = '{user}' AND pass = '{password}'";
                OleDbCommand fio1 = new OleDbCommand(quary1, con);
                string FIO1 = fio1.ExecuteScalar().ToString();

                this.Hide();
                MessageBox.Show($"Добро пожаловать, {FIO1}!");
                new Admin().ShowDialog();
                this.Close();
            }
            else if (dt.Rows.Count == 1 && dt.Rows[0][0].ToString() == "Менеджер")
            {
                string quary2 = $"SELECT ФИО FROM user1 WHERE login = '{user}' AND pass = '{password}'";
                OleDbCommand fio2 = new OleDbCommand(quary2, con);
                string FIO2 = fio2.ExecuteScalar().ToString();

                this.Hide();
                MessageBox.Show($"Добро пожаловать, {FIO2}!");
                new manager().ShowDialog();             
                this.Close();
            }

              

                con.Close();
        }

        private void Polsovatel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
