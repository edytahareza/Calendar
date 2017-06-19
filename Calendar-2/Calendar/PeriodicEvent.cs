using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    class PeriodicEvent : Event // Derived class from Event class
    {
        public DateTime EndDate { get; set; }
        public TimeSpan Frequency { get; set; }
        public PeriodicEvent(DateTime startDate, string evInformation, bool priority, DateTime endDate, TimeSpan frequency) : 
            base(startDate, evInformation, priority) { EndDate = endDate; Frequency = frequency; }

        /* Adds frequency to date and returns if next event if not outdated */

        public bool nextDate() 
        {
            Date = Date + Frequency;
            return (Date.Date <= EndDate.Date);
        }

        /* Writes all events from one period to list */

        public List<DateTime> getEventDates()
        {
            List<DateTime> list = new List<DateTime>();
            DateTime temp = this.Date;
            while(temp<=EndDate)
            {
                list.Add(temp);
                temp = temp + Frequency;
            }
            return list;
        }

        /* Writes event in special format */

        public override string ToString()
        {
            return String.Format
                (
                    "{0} {1} {2} Period in days: {3}",
                    Date.ToString("dd/MM/yyyy"),
                    EventInformation,
                    EndDate.ToString("dd/MM/yyyy"),
                    Frequency.Days
                );
        }

        /* Checks if current date is date of one from list */

        public override bool checkForDate(DateTime date)
        {
            List<DateTime> list = this.getEventDates();
            foreach (var item in list)
            {
                if (item.Date == date)
                    return true;
            }
            return false;
        }
    }
}
