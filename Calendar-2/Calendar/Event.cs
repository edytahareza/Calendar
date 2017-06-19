using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public abstract class Event // Abstract base class to all specific events
    {
        public DateTime Date { get; set; }
        public string EventInformation { get; set; }
        public bool Priority { get; set; }
        public Event() { }
        public Event(DateTime date, string evInformation, bool priority) { Date = date; EventInformation = evInformation; Priority = priority; }

        /* Writes date and information in specific format */

        public override string ToString()
        {
            return Date.ToString("dd/MM/yyyy") + " " + EventInformation;
        }

        /* Checks if date is going */

        public abstract bool checkForDate(DateTime date);
    }
}
