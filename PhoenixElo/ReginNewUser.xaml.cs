using Microsoft.Data.SqlClient;
using System;
using System.Data;
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
using WPF_Database;
using WPF_Database.Models;

namespace PhoenixElo
{
    /// <summary>
    /// Логика взаимодействия для ReginNewUser.xaml
    /// </summary>
    public partial class ReginNewUser : Window
    {
        private readonly ApplicationDBContext _context;
        public ReginNewUser(ApplicationDBContext context)
        {
            _context = context;
            InitializeComponent();
        }

        private async void btnReg_Click(object sender, RoutedEventArgs e)
        {
            var newUser = new User()
            {
                UserName = InputEmail.Text,
                Password = InputRegPassword.Password
            };
            if (InputEmail.Text != null && InputRegPassword.Password != null && InputRegPassword.Password == InputRegPasswordRepeat.Password)
            {
                await _context.CreateUser(newUser);
                MessageBox.Show("Вы успешно зарегистрировались");
                this.Close();
            }
            else
            {
                MessageBox.Show("Данные не верно заполнены");
            }
        }
    }
}
