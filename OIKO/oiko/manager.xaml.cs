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

namespace oiko
{
    /// <summary>
    /// Логика взаимодействия для manager.xaml
    /// </summary>
    public partial class manager : Window
    {
        public manager()
        {
            InitializeComponent();          
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            учет учет = new учет();
            учет.Show();
            this.Close();
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            new MainWindow().ShowDialog();
            
        }

       
    }
}
