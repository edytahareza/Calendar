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
using System.Windows.Shapes;

namespace Calendar
{
    /// <summary>
    /// Interaction logic for addWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
            periodList.ItemsSource = new List<TimePeriodEnum>() // Options of perdiods 
            {
                new TimePeriodEnum() { TimeString = "1 DAY", TimeValue = new TimeSpan(1,0,0,0) },
                new TimePeriodEnum() { TimeString = "3 DAYS", TimeValue = new TimeSpan(3,0,0,0) },
                new TimePeriodEnum() { TimeString = "5 DAYS", TimeValue = new TimeSpan(5,0,0,0) },
                new TimePeriodEnum() { TimeString = "1 WEEK", TimeValue = new TimeSpan(7,0,0,0) },
                new TimePeriodEnum() { TimeString = "2 WEEKS", TimeValue = new TimeSpan(14,0,0,0) },
            };
        }

        public ICollection<Event> collection { get; set; }

        /* Saving information from windows fields to adequate variables and creating new event */

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            string information = informationTextBox.Text;
            bool priority = priorityCheckBox.IsChecked.GetValueOrDefault();
            DateTime startDate;
            bool beginDateParsed = true;
            int day = 0;
            int month = 0;
            int year = 0;
            int endDay = 0;
            int endMonth = 0;
            int endYear = 0;

            try // Trying to parse string in textbox to day variable
            {
                int value = Int32.Parse(startDayTextBox.Text);
                day = value;
            }
            catch (Exception ex) // In case of failure textbox changes it's color to red
            {
                startDayTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                beginDateParsed = false;
            }

            try // Trying to parse string in textbox to month variable
            {
                int value = Int32.Parse(startMonthTextBox.Text);
                month = value;
            }
            catch (Exception ex) // In case of failure textbox changes it's color to red
            {
                startMonthTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                beginDateParsed = false;
            }

            try // Trying to parse string in textbox to year variable
            {
                int value = Int32.Parse(startYearTextBox.Text);
                year = value;
            }
            catch (Exception ex) // In case of failure textbox changes it's color to red
            {
                startYearTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                beginDateParsed = false;
            }

            if (beginDateParsed)
            {
                bool endDateParsed = true;
                startDate = new DateTime(year, month, day);
                
                if (longtermEventCheckBox.IsChecked.HasValue && longtermEventCheckBox.IsChecked.Value)
                {
                    try // Trying to parse string in textbox to endDay variable
                    {
                        int value = Int32.Parse(endDayTextBox.Text);
                        endDay = value;
                    }
                    catch (Exception ex) // In case of failure textbox changes it's color to red
                    {
                        endDayTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                        endDateParsed = false;
                    }

                    try // Trying to parse string in textbox to endMonth variable
                    {
                        int value = Int32.Parse(endMonthTextBox.Text);
                        endMonth = value;
                    }
                    catch (Exception ex) // In case of failure textbox changes it's color to red
                    {
                        endMonthTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                        endDateParsed = false;
                    }

                    try // Trying to parse string in textbox to endYear variable
                    {
                        int value = Int32.Parse(endYearTextBox.Text);
                        endYear = value;
                    }
                    catch (Exception ex) // In case of failure textbox changes it's color to red
                    {
                        endYearTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                        endDateParsed = false;
                    }

                    if (endDateParsed)
                    {
                        DateTime endDate = new DateTime(endYear, endMonth, endDay);
                        Event ev = new LongtermEvent(startDate, information, priority, endDate);
                        collection.Add(ev);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("End date is wrong.");
                    }
                }
                else if (periodicEventCheckBox.IsChecked.HasValue && periodicEventCheckBox.IsChecked.Value)
                {
                    try // Trying to parse string in textbox to endDay variable
                    {
                        int value = Int32.Parse(endDayTextBox.Text);
                        endDay = value;
                    }
                    catch (Exception ex) // In case of failure textbox changes it's color to red
                    {
                        endDayTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                        endDateParsed = false;
                    }

                    try // Trying to parse string in textbox to endMonth variable
                    {
                        int value = Int32.Parse(endMonthTextBox.Text);
                        endMonth = value;
                    }
                    catch (Exception ex) // In case of failure textbox changes it's color to red
                    {
                        endMonthTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                        endDateParsed = false;
                    }

                    try // Trying to parse string in textbox to endYear variable
                    {
                        int value = Int32.Parse(endYearTextBox.Text);
                        endYear = value;
                    }
                    catch (Exception ex) // In case of failure textbox changes it's color to red
                    {
                        endYearTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                        endDateParsed = false;
                    }

                    if (endDateParsed)
                    {
                        DateTime endDate = new DateTime(endYear, endMonth, endDay);
                        TimeSpan frequency = (periodList.SelectedItem as TimePeriodEnum).TimeValue;
                        Event ev = new PeriodicEvent(startDate, information, priority, endDate, frequency);
                        collection.Add(ev);
                        this.Close();
                    }
                    else // When failed to parse end date MessageBox is shown
                    {
                        MessageBox.Show("End date is wrong.");
                    }
                }
                else
                {
                    Event ev = new NormalEvent(startDate, information, priority);
                    collection.Add(ev);
                    this.Close();
                }
            }
            else // When failed to parse date there MessageBox is shown
            {
                MessageBox.Show("Date is wrong.");
            }
        }
        
        /*
         * Disables fields of periodic events and enables fields of longterm event
         * When some fields were red because of failure, they become white again
         */

        private void longtermEventCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            periodicEventCheckBox.IsChecked = false;
            endDayTextBox.IsEnabled = true;
            endMonthTextBox.IsEnabled = true;
            endYearTextBox.IsEnabled = true;

            startDayTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            startMonthTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            startYearTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            endDayTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            endMonthTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            endYearTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        /* Disables longterm fields when checkbox is unchecked */

        private void longtermEventCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            endDayTextBox.IsEnabled = false;
            endMonthTextBox.IsEnabled = false;
            endYearTextBox.IsEnabled = false;
        }

        /*
         * Disables fields of longterm events and enables fields of periodic event
         * When some fields were red because of failure, they become white again
         */

        private void periodicEventCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            longtermEventCheckBox.IsChecked = false;
            periodList.IsEnabled = true;
            endDayTextBox.IsEnabled = true;
            endMonthTextBox.IsEnabled = true;
            endYearTextBox.IsEnabled = true;
            

            startDayTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            startMonthTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            startYearTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            endDayTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            endMonthTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            endYearTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        /* Disables periodic fields when checkbox is unchecked */

        private void periodicEventCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            periodList.IsEnabled = false;
            endDayTextBox.IsEnabled = false;
            endMonthTextBox.IsEnabled = false;
            endYearTextBox.IsEnabled = false;
        }
    }

}
