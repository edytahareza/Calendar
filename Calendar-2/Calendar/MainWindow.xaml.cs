using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calendar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Timer statusTime;
        public ICollection<Event> eventCollection = new List<Event>(); // Stores all events

        public MainWindow()
        {
            EventManager.InitializeManager();
            InitializeComponent();
            this.calendar.SelectedDatesChanged += Calendar_SelectedDatesChanged;

            statusTime = new System.Timers.Timer();

            statusTime.Interval = 1000;

            statusTime.Elapsed += new System.Timers.ElapsedEventHandler(statusTimeElapsed);

            statusTime.Enabled = true;
        }

        private void statusTimeElapsed(object sender, ElapsedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                timeLabel.Content = DateTime.Now;
            });
        }

        /* Selects dates when it has event */

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedDate = this.calendar.SelectedDate;
            if (selectedDate.HasValue)
            {
                this.monthlyListView.ItemsSource = eventCollection.Where(x => x.checkForDate(selectedDate.Value.Date));
            }
            this.calendar.SelectedDatesChanged -= Calendar_SelectedDatesChanged;
            this.calendar.SelectedDates.Clear();
            foreach (var item in eventCollection)
            {
                if (item is LongtermEvent)
                {
                    LongtermEvent ev = (LongtermEvent)item;
                    this.calendar.SelectedDates.AddRange(ev.Date, ev.EndDate);
                }
                else if (item is PeriodicEvent)
                {
                    PeriodicEvent ev = (PeriodicEvent)item;
                    foreach (var it in ev.getEventDates())
                    {
                        this.calendar.SelectedDates.Add(it);
                    }                    
                }
                else
                {
                    this.calendar.SelectedDates.Add(item.Date);
                }
            }
            this.calendar.SelectedDatesChanged += Calendar_SelectedDatesChanged;
        }

        /* Opens addWindow */

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addEvent = new AddWindow();
            addEvent.collection = eventCollection;
            addEvent.ShowDialog();
        }

        /* Overrides file without old and with new events */

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            statusTime.Elapsed -= new System.Timers.ElapsedEventHandler(statusTimeElapsed);
            FileReader file = new FileReader();
            file.serializeEvents(eventCollection);
        }

        /* Writes events from file to list when windows is opening */

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FileReader file = new FileReader();
            this.eventCollection = file.deserializeEvents("events.txt");
            EventManager.Manager.CheckEventDateTimes(ref eventCollection);
        }

        /* List all todays Events when today's tab is clicked */

        private void TabItemTodays_GotFocus(object sender, RoutedEventArgs e)
        {
            todayListView.ItemsSource = eventCollection.Where(x => EventManager.Manager.checkIfToday(x)).ToList();
        }

        /* List all priority Events when priority tab is clicked */

        private void TabItemPriority_GotFocus(object sender, RoutedEventArgs e)
        {
            priorityListView.ItemsSource = eventCollection.Where(x => EventManager.Manager.checkIfPriority(x)).ToList();
        }

        /* Happens when todayButton is clicked */

        private void todayButton_Click(object sender, RoutedEventArgs e)
        {
            todayTabItem.IsSelected = true;
        }
    }
}
