using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace HP_MSA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        void EntryCompleted(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection sqlconn;
                string connsqlstring = "Server=msa.cz0sfiru3pto.us-east-1.rds.amazonaws.com;Port=3306;database=HP-MSA;User Id=gordon;Password=password;charset=utf8";
                sqlconn = new MySqlConnection(connsqlstring);
                sqlconn.Open();
                var password = ((Entry)sender).Text;
                var username = UsernameField.Text;
                string queryString = "SELECT * FROM msa.users WHERE username = {username} AND pwd = {password}";
                MySqlCommand sqlcmd = new MySqlCommand(queryString, sqlconn);
                String result = sqlcmd.ExecuteScalar().ToString();
                if (result != "")
                {
                    Navigation.PushAsync(new Dashboard());
                }
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}