using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using OxyPlot;
using OxyPlot.Xamarin.Forms;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace HP_MSA
{
	public class DashletGenerator
	{
        public PlotModel displayCapacity { get; set; }
        public PlotModel displaySystemsByRegion { get; set; }
        public PlotController controllerSystemsByRegion { get; set; }
        public PlotModel displaySystemsByFeature { get; set; }

        public DashletGenerator ()
		{
            displayCapacity = new PlotModel { Title = "Total Capacity" };

            PieSeries ps = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = .5, AngleSpan = 360, StartAngle = 0 };
            ps.Slices.Add(new PieSlice("Allocated", 2515.64));
            ps.Slices.Add(new PieSlice("Free", 4132.20));

            displayCapacity.Series.Add(ps);

            displaySystemsByRegion = new PlotModel { Title = "Systems By Region" };

            BarSeries bs = new BarSeries { StrokeColor = OxyColors.Black, StrokeThickness= 1 };
            bs.Items.Add(new BarItem { Value = 16 });
            bs.Items.Add(new BarItem { Value = 11 });
            bs.Items.Add(new BarItem { Value = 8 });
            bs.Items.Add(new BarItem { Value = 2 });

            CategoryAxis ca = new CategoryAxis { Position = AxisPosition.Left };
            ca.Labels.Add("Americas");
            ca.Labels.Add("EMEA");
            ca.Labels.Add("AMS");
            ca.Labels.Add("APJ");
            LinearAxis va = new LinearAxis { Position = AxisPosition.Bottom, AbsoluteMinimum = 0 };
            displaySystemsByRegion.Series.Add(bs);
            displaySystemsByRegion.Axes.Add(ca);
            displaySystemsByRegion.Axes.Add(va);

            controllerSystemsByRegion = new PlotController();
            controllerSystemsByRegion.UnbindAll();

            displaySystemsByFeature = new PlotModel { Title = "Systems By Feature" };

            PieSeries ps2 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = .5, AngleSpan = 360, StartAngle = 0 };
            ps2.Slices.Add(new PieSlice("CAT", 29));
            ps2.Slices.Add(new PieSlice("NAS", 28));
            ps2.Slices.Add(new PieSlice("VTL", 29));

            displaySystemsByFeature.Series.Add(ps2);

        }
	}
}