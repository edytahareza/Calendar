using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calendar
{
    class EventManager
    {

        public static EventManager Manager { get; set; }

        private EventManager() { }

        public static void InitializeManager()
        {
            Manager = new EventManager();
        }

        /* Method checks outdated dates, show MessageBox with information and deletes them */

        public void CheckEventDateTimes(ref ICollection<Event> eventCollection) 
        {
            List<Event> deletedEvents = new List<Event>();
            foreach (var item in eventCollection)
            {
                if (this.isReady(item)) // Checks if the event date is younger than current date
                {
                    MessageBox.Show(item.EventInformation);

                    if (item is PeriodicEvent)
                    {
                        PeriodicEvent ev = item as PeriodicEvent;
                        bool nextDateActivated = true;
                        while (nextDateActivated)
                        {
                            if (ev.nextDate()) // Checks if next date of periodic event is younger than current date
                            {
                                if (this.isReady(ev))
                                {
                                    MessageBox.Show(item.EventInformation);
                                }
                                else
                                {
                                    nextDateActivated = false;
                                }
                            }
                            else
                            {
                                deletedEvents.Add(item);
                                nextDateActivated = false;
                            }
                        }
                    }
                    else
                    {
                        deletedEvents.Add(item);
                    }
                }
            }

            foreach (var item in deletedEvents) // Deletes all the outdates dates
            {
                eventCollection.Remove(item);
            }
        }

        /* Check if the event will happened today */

        public bool checkIfToday(Event ev) 
        {
            DateTime now = DateTime.Now;
            DateTime eventDate = ev.Date;
            return (now.Year == eventDate.Year && now.Month == eventDate.Month && now.Day == eventDate.Day);
        }

        /* Check if the event will be hold in current month */

        //public bool checkIfMonthly(Event ev) 
        //{
        //    DateTime now = DateTime.Now;
        //    DateTime eventDate = ev.Date;

        //    if (ev is LongtermEvent)
        //    {
        //        LongtermEvent longEvent = ev as LongtermEvent;

        //        return (longEvent.Date.Date < now.Date && longEvent.EndDate.Date > now.Date);
        //    }
        //    else
        //    {
        //        return (now.Year == eventDate.Year && now.Month == eventDate.Month);
        //    }
        //}

        /* Check if the event has the priority */

        public bool checkIfPriority(Event ev) 
        {
            return ev.Priority;
        }

        /* Check if the event date is younger than current date */

        public bool isReady(Event ev)
        {
            DateTime now = DateTime.Now;
            DateTime eventDate = ev.Date;

            if (ev is LongtermEvent)
            {
                LongtermEvent longEvent = ev as LongtermEvent;

                return longEvent.EndDate.Date < now.Date;
            }
            else
            {
                return ev.Date.Date < now.Date;
            }
        }
    }
}
