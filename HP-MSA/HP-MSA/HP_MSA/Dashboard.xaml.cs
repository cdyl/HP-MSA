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
            BindingContext = new DashletGenerator(companyName);
            InitializeComponent();
            this.cName = companyName;

		}

        void moveToStorageList(object sender, EventArgs args)
        {
            //Navigation.PushAsync(new StorageList(this.cName));
            App.Current.MainPage = new StorageList(this.cName);
        }

        private void moveToMenu(object sender, EventArgs args)
        {
            App.Current.MainPage = new Menu(this);
        }
	}

}