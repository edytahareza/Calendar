using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    class LongtermEvent : Event // Derived class from Event class
    {
        public DateTime EndDate { get; set; }
        public LongtermEvent(DateTime startDate, string evInformation, bool priority, DateTime endDate) : 
            base(startDate, evInformation, priority) { EndDate = endDate; }

        /* Checks if current date is within start date and end date of event */

        public override bool checkForDate(DateTime date)
        {
            return date >= Date && date <= EndDate;
        }
    }
}
