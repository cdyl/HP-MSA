using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Net;

using OxyPlot;
using OxyPlot.Xamarin.Forms;
using OxyPlot.Series;
using OxyPlot.Axes;



using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace HP_MSA
{
    public class DashletGenerator
    {
        public PlotModel displayCapacity { get; set; }
        public PlotModel displaySystemsByRegion { get; set; }
        public PlotController controllerSystemsByRegion { get; set; }
        public PlotModel displaySystemsByFeature { get; set; }

        public DashletGenerator(string companyName)
        {
            List<Unit> items = new List<Unit>();
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri("http://54.173.140.216:8080"));
            var postData = "query=SELECT `capacity.total.freeTiB`, systemName, serialNumber, `location.region`, `capacity.total.sizeTiB` FROM msa.data WHERE companyName = '" + companyName + "'";
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
           
            var mach_to_region = new System.Collections.Generic.Dictionary<string, string>();
            var region_to_count = new System.Collections.Generic.Dictionary<string, int>();
            var region_set = new System.Collections.Generic.HashSet<string>();
            var region_list = new List<string>();

            for (int i = 0; i < raw_data.Count; i++)
            {
                string[] unitInfo = raw_data[i].Split(',');
                items.Add(new Unit()
                {
                    capacity = unitInfo[0],
                    systemName = unitInfo[1],
                    serialNumber = unitInfo[2],
                    region = unitInfo[3],
                    total_cap = unitInfo[4]
                });
                region_list.Add((unitInfo[3]));
                region_set.Add(unitInfo[3]);
                mach_to_region[unitInfo[1]] = unitInfo[3];
            }

            displayCapacity = new PlotModel { Title = "Total Capacity" };



            float avg_allocated = 0;
            float avg_free = 0;
            for (int i = 0; i < items.Count; i++)
            {
                avg_allocated += (float.Parse(items[i].total_cap) - float.Parse(items[i].capacity));
                avg_free += float.Parse(items[i].capacity);
            }
            avg_allocated /= items.Count();
            avg_free /= items.Count();

            PieSeries ps = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = .5, AngleSpan = 360, StartAngle = 0 };
            ps.Slices.Add(new PieSlice("Allocated", avg_allocated));
            ps.Slices.Add(new PieSlice("Free", avg_free));

            displayCapacity.Series.Add(ps);

            displaySystemsByRegion = new PlotModel { Title = "Systems By Region" };

            //postData = "query=SELECT `location.region`, systemName, serialNumber FROM msa.data WHERE companyName = '" + companyName + "'";
            //data = Encoding.ASCII.GetBytes(postData);
            //request.Method = "POST";
            //request.ContentType = "application/x-www-form-urlencoded";
            //request.ContentLength = data.Length;
            //using (var stream = request.GetRequestStream())
            //{
            //    stream.Write(data, 0, data.Length);
            //}

            //response = (HttpWebResponse)request.GetResponse();
            //responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            //raw_data = new List<String>();
            //rgx = new Regex(@"\[.*?\]");
            //rgx2 = new Regex("[^a-zA-Z0-9\\.\\(\\)\\-\\:\\, -]");
            //temp = "";
            //foreach (Match match in rgx.Matches(responseString))
            //{
            //    temp = rgx2.Replace(match.Value, "");
            //    raw_data.Add(temp);
            //}



            //for (int i = 0; i < raw_data.Count; i++)
            //{
            //    string[] unitInfo = raw_data[i].Split(',');
            //    items.Add(new Unit()
            //    {
            //        region = unitInfo[0],
            //        systemName = unitInfo[1],
            //        serialNumber = unitInfo[2]
            //    });

            //}

            BarSeries bs = new BarSeries { StrokeColor = OxyColors.Black, StrokeThickness = 1 };
            CategoryAxis ca = new CategoryAxis { Position = AxisPosition.Left };
            if (region_set.Count() > 1)
            {
                foreach (string region in region_list)
                {
                    region_to_count[region] += 1;
                }

                foreach (string reg in region_to_count.Keys)
                {
                    bs.Items.Add(new BarItem { Value = region_to_count[reg] });
                    ca.Labels.Add(reg);
                }
            }


            else
            {
                bs.Items.Add(new BarItem { Value = 16 });
                bs.Items.Add(new BarItem { Value = 11 });
                bs.Items.Add(new BarItem { Value = 8 });
                bs.Items.Add(new BarItem { Value = 2 });

                ca.Labels.Add("Americas");
                ca.Labels.Add("EMEA");
                ca.Labels.Add("AMS");
                ca.Labels.Add("APJ");
            }


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