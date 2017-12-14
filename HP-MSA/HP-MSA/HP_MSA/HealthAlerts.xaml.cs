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
	public partial class HealthAlerts : ContentPage
	{
        private Menu lastPage { get; set; }

        public HealthAlerts (Menu menu)
		{
            InitializeComponent();
            lastPage = menu;
            List<Alert> items = new List<Alert>();
            items.Add(new Alert() { StorageID = "DKSJ38JD", AlertMessage = "Storage Space Low" });
            Alerts.ItemsSource = items;
        }
        
        private void goBack(Object o, EventArgs e)
        {
            App.Current.MainPage = lastPage;
        }

    }

    
    public class Alert
    {
        public String StorageID { get; set; }
        public String AlertMessage { get; set; }
    }
}