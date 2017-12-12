using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Net;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


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
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri("http://54.173.140.216:8080"));
            var password = ((Entry)sender).Text;
            var username = UsernameField.Text;
            var postData = "query=SELECT * FROM msa.users WHERE username = '" + username + "' AND pwd = '" + password + "'";
            var data = Encoding.ASCII.GetBytes(postData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            if (responseString != "")
            {
                Navigation.PushAsync(new Dashboard());
            }
        }
    }
}