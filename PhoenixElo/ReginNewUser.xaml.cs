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

namespace PhoenixElo
{
    /// <summary>
    /// Логика взаимодействия для ReginNewUser.xaml
    /// </summary>
    public partial class ReginNewUser : Window
    {

        public ReginNewUser()
        {
            InitializeComponent();
        }

        // регистрация
        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=COMPUTER\SQLEXPRESS; Initial Catalog=PhoenixElo; Integrated Security=True;");
            
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "INSERT INTO [User] (UserName, Password) VALUES (@UserName, @Password)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@UserName", InputEmail.Text);
                sqlCmd.Parameters.AddWithValue("@Password", InputRegPassword.Password);

                if (InputEmail.Text.Length > 0)
                {
                    if (InputRegPassword.Password.Length > 0)
                    {
                        if (InputRegPasswordRepeat.Password.Length > 0 & InputRegPassword.Password == InputRegPasswordRepeat.Password)
                        {
                            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                            if (count == 1)
                            {
                                
                            }
                            else  
                            {
                                MessageBox.Show("Вы зарегистрировались успешно");
                            }
                        }
                        else MessageBox.Show("Повторите пороль");       
                    }
                    else MessageBox.Show("Введите пороль");
                }
                else MessageBox.Show("Введите Логин");        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }     
        }
    }
}
