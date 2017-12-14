using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HP_MSA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavBar : ContentPage
    {

        public NavBar()
        {
            Grid grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(20, GridUnitType.Absolute) }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(20, GridUnitType.Absolute) },
                    new ColumnDefinition { Width = new GridLength(20, GridUnitType.Absolute) },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = new GridLength(20, GridUnitType.Absolute) }
                }
            };

            grid.BackgroundColor = Color.FromHex("#004770");

            Button back = new Button();
            back.Image = "images/back.png";
            grid.Children.Add(back, 0, 0);

            Button search = new Button();
            search.Image = "images/search.png";
            grid.Children.Add(search, 1, 0);

            Button toggle = new Button();
            search.Text = "Dashboard";
            grid.Children.Add(toggle, 2, 0);

            Button user = new Button();
            user.Image = "images/user.png";
            grid.Children.Add(user, 3, 0);

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = grid;
        }

    }
}
