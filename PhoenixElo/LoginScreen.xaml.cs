using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private readonly ApplicationDBContext _context;
        public LoginScreen(ApplicationDBContext context)
        {
            _context = context;
            InitializeComponent();
            //Loaded += Window_Loaded;
        }
        

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {      
                var userFound = _context.Users.Any(x => x.UserName == InputName.Text && x.Password == InputPassword.Password);
                if (userFound)
                {
                    DialogResult = true;
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


        private void BtnOpenReg_Click(object sender, RoutedEventArgs e)
        {
            ReginNewUser reginNewUser = new ReginNewUser(_context);
            reginNewUser.Show();
           
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (DialogResult == null)
            {
                if (MessageBox.Show("Если вы закроете окно LoginScreen вход не будет выполнен",
                "Вы действительно хотите закрыть", MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question, MessageBoxResult.Cancel) != MessageBoxResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if ((bool)DialogResult)
            {
                MessageBox.Show("Вы успешно вошли в аккаунт");
            }
            else
            {
                MessageBox.Show("Вы не вошли в аккаунт");
                Application.Current.Shutdown();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Owner = this;
        }
    }

}
