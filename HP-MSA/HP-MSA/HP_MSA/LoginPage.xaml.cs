using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HP_MSA
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        void EntryCompleted(object sender, EventArgs e)
        {
            var password = PasswordField.Text;
            var username = UsernameField.Text;
            if( password == username)
            {
                Navigation.PushAsync(new Dashboard());
            }
        }
	}
}