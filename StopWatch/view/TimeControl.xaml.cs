using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace StopWatch.view
{
    public sealed partial class TimeControl : UserControl
    {


        public TimeSpan Time
        {
            get { return (TimeSpan)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Time.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register("Time", typeof(TimeSpan), typeof(TimeControl), new PropertyMetadata(TimeSpan.FromMilliseconds(75120),GetValue ));

        private static void GetValue(DependencyObject sender , DependencyPropertyChangedEventArgs args)
        {
            TimeControl timeControl = sender as TimeControl;

            if(timeControl != null)
            {
                var time = (TimeSpan)args.NewValue;
                timeControl.txthours.Text = string.Format("{0:00}" , time.Hours);
                timeControl.txtminuts.Text = string.Format("{0:00}", time.Minutes);
                timeControl.txtseconds.Text = string.Format("{0:00}", time.Seconds);
                timeControl.txtmilliseconds.Text = string.Format("{0:00}", time.Milliseconds /10);

                if(time.Hours == 0)
                    timeControl.txthours.Style = timeControl.Resources["inativefont"] as Style;
                else
                    timeControl.txthours.Style = timeControl.Resources["normalfont"] as Style;

                if (time.Minutes == 0)
                    timeControl.txtminuts.Style = timeControl.Resources["inativefont"] as Style;
                else
                    timeControl.txtminuts.Style = timeControl.Resources["normalfont"] as Style;

                if (time.Seconds == 0)
                    timeControl.txtseconds.Style = timeControl.Resources["inativefont"] as Style;
                else
                    timeControl.txtseconds.Style = timeControl.Resources["normalfont"] as Style;
            }
        }




        public double elementsize
        {
            get { return (double)GetValue(elementsizeProperty); }
            set { SetValue(elementsizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for elementsize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty elementsizeProperty =
            DependencyProperty.Register("elementsize", typeof(double), typeof(TimeControl ), new PropertyMetadata(1 , GetDouble));

        private static void GetDouble(DependencyObject sender , DependencyPropertyChangedEventArgs args)
        {
            TimeControl timeControl = sender as TimeControl;

            if(timeControl != null)
            {
                int width = (int)(200 * (double)args.NewValue);
                timeControl.MainContainer.Width = width;

                int heght = (int)(43 * (double)args.NewValue);
                timeControl.MainContainer.Height = heght;

                int fontsize = (int)(40 * (double)args.NewValue);
                timeControl.txthours.FontSize = fontsize;
                timeControl.txtminuts.FontSize = fontsize;
                timeControl.txtseconds.FontSize = fontsize;
                timeControl.txt1.FontSize = timeControl.txt2.FontSize = timeControl.txt3.FontSize = fontsize;
                timeControl.txtmilliseconds.FontSize = fontsize / 2;
            }
        }


        public TimeControl()
        {
            this.InitializeComponent();
        }
    }
}
