using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
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

namespace PhoenixElo
{
    /// <summary>
    /// Логика взаимодействия для LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        ApplicationDBContext _context = new ApplicationDBContext();
        public LoginScreen()
        {
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userFound = _context.Users.Any(x => x.UserName == InputName.Text && x.Password == InputPassword.Password);
                if (userFound) 
                {
                    MainWindow f = new MainWindow();
                    f.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Данные не корректны");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }
        
        private void btnOpenReg_Click(object sender, RoutedEventArgs e)
        {
            ReginNewUser reginNewUser = new ReginNewUser();
            reginNewUser.Show();
           
        }


    }

}
