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
	public partial class Dashboard : ContentPage
	{
		public Dashboard ()
		{
            BindingContext = new DashletGenerator();
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent ();
		}

        void moveToStorageList(object sender, EventArgs args)
        {
            Navigation.PushAsync(new StorageList());
        }
	}

}