using PhoenixElo;
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
using static System.Net.Mime.MediaTypeNames;

namespace WPF_Database
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        ApplicationDBContext context = new ApplicationDBContext();

        public UserWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            context.Requests.Add(new Models.Request
            {
                Id = Guid.NewGuid(),
                CreatedTime = DateTime.UtcNow,
                Content = text.Text,
                UserId = MainWindow.AuthorizedUser.UserID,
                IsCompleted = false
            });
            text.Text = "";
            MessageBox.Show("Заявка отправлена!");
            

            await context.SaveChangesAsync();
        }
    }
}
