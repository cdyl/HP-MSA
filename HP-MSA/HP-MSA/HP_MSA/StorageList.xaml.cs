using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HP_MSA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StorageList : ContentPage
    {
        List<Unit> items = new List<Unit>();
        private string companyName { get; set; }
        public StorageList(string companyName)
        {
            InitializeComponent();
            this.companyName = companyName;
            searchcustomer.IsVisible = false;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri("http://54.173.140.216:8080"));
            var postData = "query=SELECT * FROM msa.data WHERE companyName = '" + companyName + "'";
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
            List<String> raw_data = new List<String>();
            Regex rgx = new Regex(@"\[.*?\]");
            Regex rgx2 = new Regex("[^a-zA-Z0-9\\.\\(\\)\\-\\:\\, -]");
            string temp = "";
            foreach (Match match in rgx.Matches(responseString))
            {
                temp = rgx2.Replace(match.Value, "");
                raw_data.Add(temp);
            }
            for (int i = 0; i < raw_data.Count; i++){
                string[] unitInfo = raw_data[i].Split(',');
                items.Add(new Unit() { systemName = unitInfo[1], serialNumber = unitInfo[2], productFamily = unitInfo[3], 
                    model = unitInfo[4], osVersion = unitInfo[5], cpgCount = unitInfo[6], updated = unitInfo[11], 
                    nodeCount = unitInfo[12], diskCount = unitInfo[14], vvCount = unitInfo[19] });
            }
            Storage.ItemsSource = items;
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            List<Unit> moditems = new List<Unit>();
            Storage.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                Storage.ItemsSource = items;
            else
                Storage.ItemsSource = items.Where(i => i.systemName.Contains(e.NewTextValue) || i.serialNumber.Contains(e.NewTextValue)
                                                  || i.productFamily.Contains(e.NewTextValue) || i.osVersion.Contains(e.NewTextValue)
                                                  || i.model.Contains(e.NewTextValue) || i.cpgCount.Contains(e.NewTextValue)
                                                  || i.nodeCount.Contains(e.NewTextValue) || i.diskCount.Contains(e.NewTextValue));

            Storage.EndRefresh();
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            App.Current.MainPage = new DiskInfo((Unit)e.SelectedItem,companyName);
        }

        void moveToDashboard(object sender, EventArgs e)
        {
            App.Current.MainPage = new Dashboard(companyName);
        }

        void moveToMenu(object sender, EventArgs e)
        {
            App.Current.MainPage = new Menu(this,companyName);
        }

        void toggleVisibility(object sender, EventArgs e)
        {
            searchcustomer.IsVisible=!searchcustomer.IsVisible;
        }
    }

    public class Unit
    {
        public String systemName { get; set; }
        public String serialNumber { get; set; }
        public String productFamily { get; set; }
        public String model { get; set; }
        public String osVersion { get; set; }
        public String cpgCount { get; set; }
        public String updated { get; set; }
        public String nodeCount { get; set; }
        public String diskCount { get; set; }
        public String vvCount { get; set; }
        public String capacity { get; set; }
        public String region { get; set; }
        public String total_cap { get; set; }
    }
};

