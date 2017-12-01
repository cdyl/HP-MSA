using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using OxyPlot;
using OxyPlot.Xamarin.Forms;
using OxyPlot.Series;

namespace PieChartExample
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            this.MainPage = new ContentPage
            {
                Content = new PlotView
                {
                    Model = CreatePlotModel(),
                },
            };

         
		}

		protected override void OnStart ()
		{
            // Handle when your app starts

           
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
            // Handle when your app resumes

        }

        private PlotModel CreatePlotModel()
        {

            var plotModel = new PlotModel { Title = "OxyPlot Demo" };

            var ps = new PieSeries
            {
                StrokeThickness = .25,
                InsideLabelPosition = .25,
                AngleSpan = 360,
                StartAngle = 0
            };

            ps.Slices.Add(new PieSlice("Africa", 1030) { IsExploded = false });
            ps.Slices.Add(new PieSlice("Americas", 929) { IsExploded = false });
            ps.Slices.Add(new PieSlice("Asia", 4157));
            ps.Slices.Add(new PieSlice("Europe", 739) { IsExploded = false });
            ps.Slices.Add(new PieSlice("Oceania", 35) { IsExploded = false });
            plotModel.Series.Add(ps);
            return plotModel;
        }
    }
}
