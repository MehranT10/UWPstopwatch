using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace StopWatch.Models
{
    public class M1Swatch : INotifyPropertyChanged
    {
        private TimeSpan timevar;

        public TimeSpan Timevar
        {
            get { return timevar; }
            set
            {
                timevar = value;
                OnPropertyChanged("Timevar");
            }
        }

        public ObservableCollection<TimeSpan> Laps { set; get; }
        public ObservableCollection<TimeSpan> splits { set; get; }

        public M1Swatch()
        {
            this.Laps = new ObservableCollection<TimeSpan>();
            this.splits = new ObservableCollection<TimeSpan>();
            this.Timevar = new TimeSpan();
            if (DesignMode.DesignModeEnabled)
            {
                this.Timevar = TimeSpan.FromSeconds(74560);
                for (int i = 0; i <= 10; i++)
                {
                    this.Laps.Add(TimeSpan.FromMilliseconds(i * 11111));
                    this.splits.Add(TimeSpan.FromMilliseconds(i * 111111));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddLab(TimeSpan lab)
        {
            this.Laps.Add(lab);
            this.splits.Add(this.timevar);
        }
    }
}
