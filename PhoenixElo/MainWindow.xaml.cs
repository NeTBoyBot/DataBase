using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PhoenixElo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {

        ApplicationDBContext context = new ApplicationDBContext();

        public MainWindow()
        {
            InitializeComponent();
            EmployeesList.ItemsSource = context.GetAll().ToList();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            StartLogin();
        }

        public void StartLogin()
        {
            LoginScreen loginScreen = new LoginScreen(context);
            loginScreen.Owner = this;
            loginScreen.ShowDialog();
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
            try
            {
                Window1 window1 = new Window1(context);
                window1.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Read();
            }
        }


        private async void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedCycle = EmployeesList.SelectedItem as Motorcycle;
                var motorcycle = context.GetAll().FirstOrDefault(x => x.ID == selectedCycle.ID);

                if (selectedCycle != null)
                {
                    motorcycle.Name = Name_txt.Text;
                    motorcycle.Price = int.Parse(Price_txt.Text);
                    motorcycle.MaxSpeed = int.Parse(MaxSpeed_txt.Text);
                    await context.Update(motorcycle);
                    Read();
                }
            }
            catch
            {
                MessageBox.Show("Вы не выбрали элемент для обновление!");
            }
                  
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
