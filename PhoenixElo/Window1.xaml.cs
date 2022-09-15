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
            var cycle = new Motorcycle()
            {
                Name = name_txt.Text,
                Price = int.Parse(Price_txt.Text),
                MaxSpeed = int.Parse(maxspeed.Text)
            };

            await _context.Create(cycle);
        }
    }
}
