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

namespace WpfTabNavigation
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            this.notifyCount.Text = "20";
            // 应用下拉日历样式
            TextBox tb = new TextBox();            
            Style sCalendar = (Style)tb.TryFindResource("tbCalendarStyle");
            if (sCalendar != null)
                this.datePick.Style = sCalendar;
            //应用动画
            System.Windows.Media.Animation.Storyboard s = (System.Windows.Media.Animation.Storyboard)TryFindResource("sb");
            s.Begin();	// Start animation

        }

   
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }



        private void Logout_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
         
            this.Close();
        }

        private void Label_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {

            this.pageContainer.Source = new Uri("pages/Page_Chart.xaml", UriKind.RelativeOrAbsolute);

        }
        private bool __isLeftHide = false;
        private void spliter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Left Bar hide and show
            __isLeftHide =! __isLeftHide;
            if (__isLeftHide)
            {
                this.gridForm.ColumnDefinitions[0].Width = new GridLength(1d);
            }
            else
            {
                this.gridForm.ColumnDefinitions[0].Width = new GridLength(200d);
            }
          
        }

        private void Label_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            this.pageContainer.Source = new Uri("pages/Page_Chart2.xaml", UriKind.RelativeOrAbsolute);
        }

        private void TabItem_MouseMove_1(object sender, MouseEventArgs e)
        {
             //var part_text= this.LeftTabControl.Template.FindName("PART_Text", this.LeftTabControl);
            //null
        }

     
    }
}
