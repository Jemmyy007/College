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
using System.Windows.Shapes;
using System.Data.Odbc;

namespace oiko
{
    /// <summary>
    /// Логика взаимодействия для учет.xaml
    /// </summary>
    public partial class учет : Window
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        OleDbDataAdapter da;
        DataSet ds;
        public учет()
        {
            InitializeComponent();

            comStatus.SelectedIndex = 0;
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Database oiko.accdb");

            cmd = new OleDbCommand();
            con.Open();

            da = new OleDbDataAdapter("select * from uchet", con);
            ds = new DataSet();
            da.Fill(ds, "uchet");

            GridUchet.ItemsSource = ds.Tables["uchet"].DefaultView;

            con.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new manager().ShowDialog();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Database oiko.accdb");

            cmd = new OleDbCommand();
            con.Open();

            string ins = txtInsert.Text;
            string status = comStatus.Text;
            string date = DateTime.Now.ToShortDateString();


            if (txtInsert.Text == "")
            {

                MessageBox.Show("Вы не ввели тип оборудования");

            }

            else
            {
                string quary = $"INSERT INTO uchet ([Тип и модель оборудования], Статус, [Дата приобретения]) VALUES ('{ins}', '{status}', '{date}')";
                cmd = new OleDbCommand(quary, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Запись добавлена");

                da = new OleDbDataAdapter("select * from uchet", con);
                ds = new DataSet();
                da.Fill(ds, "uchet");

                GridUchet.ItemsSource = ds.Tables["uchet"].DefaultView;

                con.Close();

                txtInsert.Text = "";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Database oiko.accdb");

            cmd = new OleDbCommand();
            con.Open();
            try
            {
                int kod = Convert.ToInt32(txtUP.Text);
                string up = txtUpdate.Text;
                string status = comStatus2.Text;

                OleDbDataAdapter da = new OleDbDataAdapter($"SELECT * FROM uchet WHERE Код = {kod}", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string quary = $"UPDATE uchet SET [Тип и модель оборудования] = '{up}', Статус = '{status}' WHERE Код = {kod}";
                    cmd = new OleDbCommand(quary, con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Получилось");

                    txtUP.Text = "";
                    comStatus2.SelectedIndex = -1;
                    txtUpdate.Text = "";

                    da = new OleDbDataAdapter("select * from uchet", con);
                    ds = new DataSet();
                    da.Fill(ds, "uchet");

                    GridUchet.ItemsSource = ds.Tables["uchet"].DefaultView;

                }
                else
                {
                    MessageBox.Show("Такой записи не существует!");
                    txtUP.Text = "";
                    comStatus2.SelectedIndex = -1;
                    txtUpdate.Text = "";
                }



            }
            catch (FormatException)
            {
                MessageBox.Show("Введите КОД!");
                txtUP.Text = "";
                comStatus2.SelectedIndex = -1;
                txtUpdate.Text = "";
            }
            con.Close();
        }

        private void txtDelete_TextChanged(object sender, TextChangedEventArgs e)
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Database oiko.accdb");

            cmd = new OleDbCommand();
            con.Open();
            try
            {
                con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Database oiko.accdb");

                cmd = new OleDbCommand();
                con.Open();

                int kod = Convert.ToInt32(txtUP.Text);

                
                string quary = $"SELECT [Тип и модель оборудования] FROM uchet WHERE Код = {kod}";
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(quary, con);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {


                    string quary3 = $"SELECT [Тип и модель оборудования] FROM uchet WHERE Код = {kod}";
                    OleDbCommand cmd3 = new OleDbCommand(quary3, con);


                    string g = cmd3.ExecuteScalar().ToString();

                   if (g != null)
                    {


                        txtUpdate.Text = g;

                        string quary2 = $"SELECT [Статус] FROM uchet WHERE Код = {kod}";
                        cmd = new OleDbCommand(quary2, con);
                        string g2 = cmd.ExecuteScalar().ToString();
                      //int ind =comStatus2.Items.IndexOf(comStatus2.FindName(g2));

                        comStatus2.Text = g2;

                        

                    }
                    
                   
                }
               
            }
            catch(Exception ex)
            {

            }
        }

        private void txtUP_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtUP.Text == "")
            {
                txtUpdate.Text = "";
                comStatus2.SelectedIndex = -1;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Database oiko.accdb");

            cmd = new OleDbCommand();
            con.Open();
            try
            {
                int kod = Convert.ToInt32(txtUP.Text);
                string up = txtUpdate.Text;
                string status = comStatus2.Text;

                
                
               OleDbDataAdapter da = new OleDbDataAdapter($"SELECT * FROM uchet WHERE Код = {kod}", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string quary = $"DELETE * from uchet WHERE Код = {kod}";
                    cmd = new OleDbCommand(quary, con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Запись удалена");

                    txtUP.Text = "";
                    comStatus2.SelectedIndex = -1;
                    txtUpdate.Text = "";

                    da = new OleDbDataAdapter("select * from uchet", con);
                    ds = new DataSet();
                    da.Fill(ds, "uchet");

                    GridUchet.ItemsSource = ds.Tables["uchet"].DefaultView;

                }
                else
                {
                    MessageBox.Show("Такой записи не существует!");
                    txtUP.Text = "";
                    comStatus2.SelectedIndex = -1;
                    txtUpdate.Text = "";
                }
               


            }
            catch (FormatException)
            {
                MessageBox.Show("Введите КОД!");
                txtUP.Text = "";
                comStatus2.SelectedIndex = -1;
                txtUpdate.Text = "";
            }
            con.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Pechat pechat = new Pechat();
            pechat.Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Database oiko.accdb");

            cmd = new OleDbCommand();
            con.Open();
            string search = txtSearch.Text;

            da = new OleDbDataAdapter($"select * from uchet WHERE [Тип и модель оборудования] LIKE '%{search}%' OR Статус LIKE '%{search}%' OR [Дата приобретения] LIKE '%{search}%'", con);
            ds = new DataSet();
            da.Fill(ds, "uchet");

            GridUchet.ItemsSource = ds.Tables["uchet"].DefaultView;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Database oiko.accdb");

            cmd = new OleDbCommand();
            con.Open();

            da = new OleDbDataAdapter("select * from uchet", con);
            ds = new DataSet();
            da.Fill(ds, "uchet");

            GridUchet.ItemsSource = ds.Tables["uchet"].DefaultView;

            con.Close();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Database oiko.accdb");

            cmd = new OleDbCommand();
            con.Open();

            da = new OleDbDataAdapter("select * from uchet WHERE Статус = 'На складе'", con);
            ds = new DataSet();
            da.Fill(ds, "uchet");

            GridUchet.ItemsSource = ds.Tables["uchet"].DefaultView;

            con.Close();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Database oiko.accdb");

            cmd = new OleDbCommand();
            con.Open();

            da = new OleDbDataAdapter("select * from uchet WHERE Статус = 'Используется'", con);
            ds = new DataSet();
            da.Fill(ds, "uchet");

            GridUchet.ItemsSource = ds.Tables["uchet"].DefaultView;

            con.Close();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Database oiko.accdb");

            cmd = new OleDbCommand();
            con.Open();

            da = new OleDbDataAdapter("select * from uchet WHERE Статус = 'Неисправно'", con);
            ds = new DataSet();
            da.Fill(ds, "uchet");

            GridUchet.ItemsSource = ds.Tables["uchet"].DefaultView;

            con.Close();
        }
    }
    }

    
    

