using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhoenixElo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        public List<Motorcycle> Motorcycles { get; private set; }

        ApplicationDBContext context = new ApplicationDBContext();


        public MainWindow()
        {
            InitializeComponent();
            
            EmployeesList.ItemsSource = context.GetAll().ToList();
        }

        public void Read()
        {
            EmployeesList.ItemsSource = context.GetAll().ToList();
        }

        private void ReadBtn_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void EmployeesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1(context);
            window1.Show();
            
        }


        private async void UpdateBtn_Click(object sender, RoutedEventArgs e) 
        {
            var mot = Cycle();
            Motorcycle selectedCycle = EmployeesList.SelectedItem as Motorcycle;
            Motorcycle motorcycle = await context.Motorcycles.FirstOrDefaultAsync(x => x.ID == selectedCycle.ID);
            if (mot != null)
            {
                motorcycle.Name = mot.Name;
                motorcycle.Price = mot.Price;
                motorcycle.MaxSpeed = mot.MaxSpeed;
                await context.SaveChangesAsync();
            }
            Read();
        }

        private Motorcycle Cycle()
        {
            var motorcycle = new Motorcycle();
            motorcycle.Name = Name_txt.Text;
            motorcycle.Price = int.Parse(Price_txt.Text);
            motorcycle.MaxSpeed = int.Parse(MaxSpeed_txt.Text);
            return motorcycle;
        }



        private async void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Motorcycle selectedCycle = EmployeesList.SelectedItem as Motorcycle;

            if (selectedCycle != null)
            {
                var motorcycle = await context.Motorcycles.FirstOrDefaultAsync(x => x.ID == selectedCycle.ID);
                await context.Delete(motorcycle);
            }

            Read();
        }
 
    }
}
