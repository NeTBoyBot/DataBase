using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPF_Database.Models;

namespace PhoenixElo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {

        public static User AuthorizedUser { get; set; }

        ApplicationDBContext context = new ApplicationDBContext();

        public MainWindow()
        {
            InitializeComponent();
            EmployeesList.ItemsSource = context.GetAll().ToList();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //StartLogin();
        }

        public void StartLogin()
        {
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.Owner = this;
            loginScreen.ShowDialog();
        }

        public void Read()
        {
            EmployeesList.ItemsSource = context.GetAll().ToList();
            RequestList.ItemsSource = context.Employees.ToList();
            DoneRequestList.ItemsSource = context.Requests.Select(r => r).Where(r => r.IsCompleted).ToList();
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
                var selectedCycle = EmployeesList.SelectedItem as Request;
                var motorcycle = context.GetAll().FirstOrDefault(x => x.Id == selectedCycle.Id);

                if (selectedCycle != null)
                {
                    //TODO
                    motorcycle.IsCompleted = true;
                    motorcycle.CompleteTime = DateTime.UtcNow;
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
            Request selectedCycle = EmployeesList.SelectedItem as Request;

            if (selectedCycle != null)
            {
                var motorcycle = await context.Requests.FirstOrDefaultAsync(x => x.Id == selectedCycle.Id);
                await context.Delete(motorcycle);
            }
            Read();
        }

        private void TabItem_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            
            
        }

        private void TabItem_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
            
        }

        private void RequestList_Loaded(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void DoneRequestList_Loaded(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            Request selectedCycle = DoneRequestList.SelectedItem as Request;

            if (selectedCycle != null)
            {
                var motorcycle = await context.Requests.FirstOrDefaultAsync(x => x.Id == selectedCycle.Id);
                await context.Delete(motorcycle);
            }
            Read();
        }
    }
}
