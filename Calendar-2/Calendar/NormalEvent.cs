using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    class NormalEvent : Event // Derived class from Event class
    {
        public NormalEvent(DateTime date, string evInformation, bool priority) : base(date, evInformation, priority) { }

        /* Checks if current date is event date */

        public override bool checkForDate(DateTime date)
        {
            return date == Date;
        }
    }
}
