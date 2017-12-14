
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
public partial class Alerts : ContentPage
{
public Alerts()
{
InitializeComponent();
List<Unit> items = new List<Unit>();
items.Add(new Unit() { StorageID = "DKSJ38JD", AlertMessage = "Storage Space Low" });
}

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
    public class Unit
    {
    public String StorageID { get; set; }
    public String AlertMessage { get; set; }
      

    }



};
