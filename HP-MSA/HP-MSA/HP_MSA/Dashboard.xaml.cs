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
        public string cName = "";
		public Dashboard (string companyName)
		{
            BindingContext = new DashletGenerator();
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            this.cName = companyName;
		}

        void moveToStorageList(object sender, EventArgs args)
        {
            Navigation.PushAsync(new StorageList(this.cName));
        }
	}

}