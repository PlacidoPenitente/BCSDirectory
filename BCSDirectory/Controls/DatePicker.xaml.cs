using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace BCSDirectory.Controls
{
    /// <summary>
    /// Interaction logic for DatePicker.xaml
    /// </summary>
    public partial class DatePicker : UserControl, INotifyPropertyChanged
    {
        public DatePicker()
        {

            InitializeComponent();

            Root.DataContext = this;

            TwentyEightDays = new ObservableCollection<string>();
            TwentyNineDays = new ObservableCollection<string>();
            ThirtyDays = new ObservableCollection<string>();
            ThirtyOneDays = new ObservableCollection<string>();

            Months = new ObservableCollection<string>()
            {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December"
            };

            Days = new ObservableCollection<string>();

            for (int i = 0; i < 31; i++)
            {
                if (i < 28) TwentyEightDays.Add((i + 1) + "");
                if (i < 29) TwentyNineDays.Add((i + 1) + "");
                if (i < 30) ThirtyDays.Add((i + 1) + "");
                ThirtyOneDays.Add((i + 1) + "");
            }

            Years = new ObservableCollection<string>();

            for (int i = 0; i < 150; i++)
            {
                Years.Add((DateTime.Now.Year - i) + "");
            }
        }

        public ObservableCollection<string> TwentyEightDays { get; set; }
        public ObservableCollection<string> TwentyNineDays { get; set; }
        public ObservableCollection<string> ThirtyDays { get; set; }
        public ObservableCollection<string> ThirtyOneDays { get; set; }

        #region MonthProperty

        private string _month = "";

        public string Month
        {
            get => _month;
            set
            {
                if (_month != value)
                {
                    _month = value;
                    OnPropertyChanged();
                    UpdateDays();
                    SetSelectedDate();
                }
            }
        }

        #endregion

        #region DayProperty

        private string _day;

        public string Day
        {
            get => _day;
            set
            {
                if (_day != value)
                {
                    _day = value;
                    OnPropertyChanged();
                    SetSelectedDate();
                }
            }
        }

        #endregion

        #region YearProperty

        private string _year;

        public string Year
        {
            get => _year;
            set
            {
                if (_year != value)
                {
                    _year = value;
                    OnPropertyChanged();
                    UpdateDays();
                    SetSelectedDate();
                }
            }
        }

        #endregion

        #region MonthsProperty

        private ObservableCollection<string> _months;

        public ObservableCollection<string> Months
        {
            get => _months;
            set
            {
                _months = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region DaysProperty

        private ObservableCollection<string> _days;

        public ObservableCollection<string> Days
        {
            get => _days;
            set
            {
                _days = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region YearsProperty

        private ObservableCollection<string> _years;

        public ObservableCollection<string> Years
        {
            get => _years;
            set
            {
                _years = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public DateTime Date
        {
            get { return (DateTime)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Date.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DateProperty =
            DependencyProperty.Register("Date", typeof(DateTime), typeof(DatePicker), new PropertyMetadata(DateTime.Now));

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateDays()
        {
            if (Month.Equals("February"))
            {
                Days = int.Parse(Year) % 4 == 0 ? TwentyNineDays : TwentyEightDays;
            }
            else if (Month.Equals("January") ||
                     Month.Equals("March") ||
                     Month.Equals("May") ||
                     Month.Equals("July") ||
                     Month.Equals("August") ||
                     Month.Equals("October") ||
                     Month.Equals("December"))
            {
                Days = ThirtyOneDays;
            }
            else
            {
                Days = ThirtyDays;
            }

            if (!Days.Any(x => x.Equals(Day)))
            {
                Day = Days[Days.Count - 1];
            }
        }

        public void SetSelectedDate()
        {
            if (String.IsNullOrEmpty(Year) || String.IsNullOrEmpty(Month) || String.IsNullOrEmpty(Day)) return;
            Date = new DateTime(int.Parse(Year), Months.IndexOf(Month) + 1, int.Parse(Day));
        }
    }
}
