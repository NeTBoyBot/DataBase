using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_Database.Models;

namespace PhoenixElo
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private readonly ApplicationDBContext _context;

        public Window1(ApplicationDBContext context)
        {
            _context = context;
            InitializeComponent();
        }

        
        private async void ClickOK_Click(object sender, RoutedEventArgs e)
        {
            var cycle = new Request()
            {
                //TODO
            };

            await _context.Create(cycle);

            this.Close();
        }
    }
}
