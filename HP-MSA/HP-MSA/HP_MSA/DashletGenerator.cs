using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using OxyPlot;
using OxyPlot.Xamarin.Forms;
using OxyPlot.Series;

namespace HP_MSA
{
	public class DashletGenerator
	{
        public PlotModel displayCapacity { get; set; }

        public DashletGenerator ()
		{
            displayCapacity = new PlotModel { Title = "Total Capacity" };

            PieSeries ps = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 1, AngleSpan = 360, StartAngle = 0 };
            ps.Slices.Add(new PieSlice("Fran", 7));
            ps.Slices.Add(new PieSlice("Nick", 22));
            ps.Slices.Add(new PieSlice("Andrew", 45));
            ps.Slices.Add(new PieSlice("Matt", 1079));

            displayCapacity.Series.Add(ps);

		}
	}
}