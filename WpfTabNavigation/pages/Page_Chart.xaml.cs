#region Author/About
/************************************************************************************
*  WPF Tab Navigation Demo (not control)                                                                                                                                  
*  Created:     2015-11-03                                                    
*  Built on:    WinServer 2008 R2(x64)                                                     
*  Purpose:    Learn WPF UI                                                
*  Revision:    1.0                                                               
*  Tested On:   WinServer 2008 R2(x64)                                                      
*  IDE:        VS2012 .NET 4.5                                         
*  Referenced:                                                       
*  Author:     JackWang-CUMT                                  
*                                                                                   
*************************************************************************************
You can not:
-Sell or redistribute this code or the binary for profit. This is freeware.
-Use this control, or porions of this code in spyware, malware, or any generally acknowledged form of malicious software.
-Remove or alter the above author accreditation, or this disclaimer.

You can:
-Use this control in private and commercial applications.
-Use portions of this code in your own projects or commercial applications.

I will not:
-Except any responsibility for this code whatsoever.
-Modify on demand.. you have the source code, read it, learn from it, write it.
-There is no guarantee of fitness, nor should you have any expectation of support. 
-I further renounce any and all responsibilities for this code, in every way conceivable, 
now, and for the rest of time.

JackWang-CUMT 
Blog:http://www.cnblogs.com/isaboy/
wangmingemail@163.com
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTabNavigation.pages
{
    using OxyPlot;
    using OxyPlot.Axes;
    using OxyPlot.Series;
    /// <summary>
    /// Page_Chart.xaml 的交互逻辑
    /// </summary>
    public partial class Page_Chart : Page
    {
        public Page_Chart()
        {
            InitializeComponent();
            this.Model = CreateNormalDistributionModel();
            this.DataContext = this;
        }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>The model.</value>
        public PlotModel Model { get; set; }

        /// <summary>
        /// Creates a model showing normal distributions.
        /// </summary>
        /// <returns>A PlotModel.</returns>
        private static PlotModel CreateNormalDistributionModel()
        {

            var plot = new PlotModel
            {
                Title = "Normal distribution",
                Subtitle = "Probability density function"
            };

            plot.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Minimum = -0.05,
                Maximum = 1.05,
                MajorStep = 0.2,
                MinorStep = 0.05,
                TickStyle = TickStyle.Inside
            });
            plot.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = -5.25,
                Maximum = 5.25,
                MajorStep = 1,
                MinorStep = 0.25,
                TickStyle = TickStyle.Inside
            });
            plot.Series.Add(CreateNormalDistributionSeries(-5, 5, 0, 0.2));
            plot.Series.Add(CreateNormalDistributionSeries(-5, 5, 0, 1));
            plot.Series.Add(CreateNormalDistributionSeries(-5, 5, 0, 5));
            plot.Series.Add(CreateNormalDistributionSeries(-5, 5, -2, 0.5));
            return plot;
        }

        private static LineSeries CreateNormalDistributionSeries(double x0, double x1, double mean, double variance, int n = 1000)
        {
            var ls = new LineSeries
            {
                Title = string.Format("μ={0}, σ²={1}", mean, variance)
            };

            for (int i = 0; i < n; i++)
            {
                double x = x0 + ((x1 - x0) * i / (n - 1));
                double f = 1.0 / Math.Sqrt(2 * Math.PI * variance) * Math.Exp(-(x - mean) * (x - mean) / 2 / variance);
                ls.Points.Add(new DataPoint(x, f));
            }

            return ls;
        }
    }
}
