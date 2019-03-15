using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using StopWatch.Models;
using StopWatch.ViweModels.Commands;

namespace StopWatch.ViweModels
{
    public class VMstopwatch : INotifyPropertyChanged
    {
        public VMstopwatch()
        {
            this.StartCommand = new StartCommand(this);
            this.NewlabCommand = new NewlabCommand(this);
            this.StopCommand = new StopCommand(this);
            this.ReloadCommand = new ReloadCommand(this);

            this.IsRunning = false;
            this.MStopwatch = new M1Swatch();
            this.StopWatch = new System.Diagnostics.Stopwatch();
            this.newLap = new System.Diagnostics.Stopwatch();
            this.timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,0,0,INTERVAL_IN_MILLISECENDS);
            timer.Tick += Timer_Tick;
        }

        public void Start ()
        {
            this.IsRunning = true;
            timer.Start();
            this.StopWatch.Start();
            newLap.Start();
        }

        public void Stop ()
        {
            this.IsRunning = false;
            timer.Stop();
            this.StopWatch.Stop();
            newLap.Stop();
        }

        public void Restart()
        {
            this.MStopwatch.Laps.Clear();
            this.MStopwatch.splits.Clear();
            this.MStopwatch = new M1Swatch();
            this.StopWatch.Reset();
        }

        public void AddLab ()
        {
            this.MStopwatch.AddLab(newLap.Elapsed);
            newLap.Restart();
        }

        public StopCommand StopCommand { set; get; }
        public StartCommand StartCommand { set; get; }
        public ReloadCommand ReloadCommand { set; get; }
        public NewlabCommand NewlabCommand { set; get; }

        private void Timer_Tick(object sender, object e)
        {
            this.MStopwatch.Timevar = this.StopWatch.Elapsed;
        }

        private const int INTERVAL_IN_MILLISECENDS = 10;
        private DispatcherTimer timer;
        private System.Diagnostics.Stopwatch newLap;

        public M1Swatch MStopwatch { set; get; }
        System.Diagnostics.Stopwatch stopwatch;
        System.Diagnostics.Stopwatch StopWatch
        {
            get { return stopwatch; }
            set
            {
                stopwatch = value;
                OnPropertyChanged("StopWatch");
            }
        }

        private bool isRunning;
        public bool IsRunning
        {
            get { return isRunning; }
            set
            {
                isRunning = value;
                OnPropertyChanged("IsRunning");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
