using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace loginapp
{
    /// <summary>
    /// Interaction logic for loginpage.xaml
    /// </summary>
    public partial class loginpage : Window
    {
        public loginpage()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Server=GOWTHAM\SQLEXPRESS;Database=Logindb;Trusted_Connection=True;"); 
            try
            {
              if (sqlcon.State == System.Data.ConnectionState.Closed)
                    sqlcon.Open();
                String query = "SELECT COUNT(1) FROM tblUser WHERE Username=@Username AND Password=@Password";
                SqlCommand sqlCommand = new SqlCommand(query, sqlcon);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Username", txtusernmame.Text);
                sqlCommand.Parameters.AddWithValue("@Password", txtpassword.Text);
                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                if(count ==1)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username eor password is incorrect");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
        }
    }
}
