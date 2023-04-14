using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.OleDb;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

namespace oiko
{
    /// <summary>
    /// Логика взаимодействия для Сотрудники.xaml
    /// </summary>
    public partial class Сотрудники : Window
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        OleDbDataAdapter da;
        DataSet ds;


        public Сотрудники()
        {
            InitializeComponent();

            comPostAdd.SelectedIndex = 1;
            txtLoginAdd.MaxLength = 15;
            txtPassAdd.MaxLength = 15;
            txtLoginChange.MaxLength = 15;
            txtPassChange.MaxLength = 15;

            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Database oiko.accdb");

            cmd = new OleDbCommand();
            con.Open();

            GRID();
           

           this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Admin().ShowDialog();
            this.Close();
        }
        private void GRID()
        {
            da = new OleDbDataAdapter("select Код, login AS Логин, pass AS Пароль, post AS Должность, ФИО from user1", con);
            ds = new DataSet();
            da.Fill(ds, "add_staff");

            GridStaff.ItemsSource = ds.Tables["add_staff"].DefaultView;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Database oiko.accdb");

            cmd = new OleDbCommand();
            con.Open();

            string login = txtLoginAdd.Text;
            string pass = txtPassAdd.Text;
            string fio = txtFIOadd.Text;
            string post = comPostAdd.Text;

            if (login == "" ||  pass == "" || fio == "")
            {
                MessageBox.Show("Введите данные для добавления!");
            }
            else
            {
                string count = $"SELECT COUNT(*) FROM user1 WHERE login = '{login}'";
                OleDbCommand cmdCount = new OleDbCommand(count, con);

                int a = Convert.ToInt32(cmdCount.ExecuteScalar());

                if (a < 1)
                {
                    string quary = $"INSERT INTO user1 (login, pass, post, ФИО) VALUES ('{login}', '{pass}', '{post}', '{fio}')";
                    cmd = new OleDbCommand(quary, con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Пользователь добавлен!");

                    GRID();
                    txtLoginAdd.Text = "";
                    txtPassAdd.Text = "";
                    txtFIOadd.Text = "";
                }
                else
                {
                    MessageBox.Show("Такой Логин уже существует!");
                    txtLoginAdd.Text = "";
                    txtPassAdd.Text = "";
                }
            }
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtKod.Text == "")
            {
                txtFIOchange.Text = "";
                txtLoginChange.Text = "";
                txtPassChange.Text = "";
                comPostChange.SelectedIndex = -1;
            }
        }

        private void txtKod_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Database oiko.accdb");

                cmd = new OleDbCommand();
                con.Open();

                int kod = Convert.ToInt32(txtKod.Text);


                string quary = $"SELECT COUNT(*) FROM user1 WHERE Код = {kod}";
                cmd = new OleDbCommand(quary , con);
                int a = Convert.ToInt32(cmd.ExecuteScalar());

                if (a > 0)
                {


                    string quary3 = $"SELECT login FROM user1 WHERE Код = {kod}";
                    string quary4 = $"SELECT pass FROM user1 WHERE Код = {kod}";
                    string quary6 = $"SELECT ФИО FROM user1 WHERE Код = {kod}";

                    OleDbCommand cmd3 = new OleDbCommand(quary3, con);
                    OleDbCommand cmd4 = new OleDbCommand(quary4, con);                   
                    OleDbCommand cmd6 = new OleDbCommand(quary6, con);

                    string g3 = cmd3.ExecuteScalar().ToString();
                    string g4 = cmd4.ExecuteScalar().ToString();                 
                    string g6 = cmd6.ExecuteScalar().ToString();

                    if (g3 != null && g4 != null && g6 != null)
                    {


                        txtFIOchange.Text = g6;
                        txtLoginChange.Text = g3;
                        txtPassChange.Text = g4;

                        string quary5 = $"SELECT post FROM user1 WHERE Код = {kod}";
                        OleDbCommand cmd5 = new OleDbCommand(quary5, con);
                        string g5 = cmd5.ExecuteScalar().ToString();


                        
                      //int ind = comPostChange.Items.IndexOf(comPostChange.FindName(g5));

                        comPostChange.Text = g5;



                    }


                }

            }
            catch (Exception ex)
            {

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Database oiko.accdb");

            cmd = new OleDbCommand();
            con.Open();
            try {
                int kod = Convert.ToInt32(txtKod.Text);
                string login = txtLoginChange.Text;
                string pass = txtPassChange.Text;
                string fio = txtFIOchange.Text;
                string post = comPostChange.Text;

                string quaey = $"SELECT COUNT(*) FROM user1 WHERE Код = {kod}";
                OleDbCommand cmdSel = new OleDbCommand(quaey, con);
                int a = Convert.ToInt32(cmdSel.ExecuteScalar());

                if (a > 0)
                {
                    string update = $"UPDATE user1 SET login = '{login}', pass = '{pass}', post = '{post}', ФИО = '{fio}' WHERE Код = {kod}";
                    OleDbCommand cmdUp = new OleDbCommand(update, con);
                    cmdUp.ExecuteNonQuery();

                    MessageBox.Show("Запись изменена!");

                    txtKod.Text = "";
                    txtFIOchange.Text = "";
                    txtPassChange.Text = "";
                    txtLoginChange.Text = "";
                    comPostChange.SelectedIndex = -1;

                    GRID();
                }
                else
                {
                    MessageBox.Show("Такой записи не существует!");
                    txtKod.Text = "";
                    txtFIOchange.Text = "";
                    txtPassChange.Text = "";
                    txtLoginChange.Text = "";
                    comPostChange.SelectedIndex = -1;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите код!");
                txtKod.Text = "";
                txtFIOchange.Text = "";
                txtPassChange.Text = "";
                txtLoginChange.Text = "";
                comPostChange.SelectedIndex = -1;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Database oiko.accdb");

            cmd = new OleDbCommand();
            con.Open();
            try
            {
                int kod = Convert.ToInt32(txtKod.Text);
                string login = txtLoginChange.Text;
                string pass = txtPassChange.Text;
                string fio = txtFIOchange.Text;
                string post = comPostChange.Text;

                string quaey = $"SELECT COUNT(*) FROM user1 WHERE Код = {kod}";
                OleDbCommand cmdSel = new OleDbCommand(quaey, con);
                int a = Convert.ToInt32(cmdSel.ExecuteScalar());

                if (a > 0)
                {
                    string update = $"DELETE * FROM user1 WHERE Код = {kod}";
                    OleDbCommand cmdUp = new OleDbCommand(update, con);
                    cmdUp.ExecuteNonQuery();

                    MessageBox.Show("Запись Удалена!");

                    txtKod.Text = "";
                    txtFIOchange.Text = "";
                    txtPassChange.Text = "";
                    txtLoginChange.Text = "";
                    comPostChange.SelectedIndex = -1;

                    GRID();
                }
                else
                {
                    MessageBox.Show("Такой записи не существует!");
                    txtKod.Text = "";
                    txtFIOchange.Text = "";
                    txtPassChange.Text = "";
                    txtLoginChange.Text = "";
                    comPostChange.SelectedIndex = -1;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите код!");
                txtKod.Text = "";
                txtFIOchange.Text = "";
                txtPassChange.Text = "";
                txtLoginChange.Text = "";
                comPostChange.SelectedIndex = -1;
            }
        }
    }
}
