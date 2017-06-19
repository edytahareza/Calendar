using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Calendar
{
    class FileReader
    {
        /* Writing events to file */

        public void serializeEvents(IEnumerable<Event> eventList) 
        {
            StreamWriter file = new StreamWriter("events.txt");
            string getResult;
            foreach (var item in eventList)
            {
                getResult = this.writeFile(item);
                file.WriteLine(getResult);                
            }
            file.Close();
        }

        /* Reading events from file */

        public ICollection<Event> deserializeEvents(string path) 
        {
            StreamReader file = new StreamReader(path);
            List<Event> eventList = new List<Event>();
            while (!file.EndOfStream)
            {
                Event ev = this.readFile(file.ReadLine());
                eventList.Add(ev);
            }
            return eventList;
        }

        /* 
         * Method used to write event to file
         * Format of event: (startDate) (information):term (priority) (eventType) (endDate) (frequency)
         * Event types: 0 - NormalEvent
         *              1 - PeriodicEvent
         *              2 - LongtermEvent
         */

        public string writeFile(Event ev) 
        {
            string text;
           
            DateTime dateTime = DateTime.Now;
            long dataInLong = ev.Date.ToBinary();
            text = dataInLong.ToString();
            text += " " + ev.EventInformation + ":term" ;
            if (ev.Priority)
                text += " 1";
            else
                text += " 0";

            if (ev is NormalEvent)
            {
                text += " 0";
            }

            else if (ev is PeriodicEvent)
            {
                PeriodicEvent myEvent = (PeriodicEvent)ev;
                text += " 1";
                long endDateInLong = myEvent.EndDate.ToBinary();
                text += " " + endDateInLong.ToString();
                text += " " + myEvent.Frequency.ToString();
            }

            else if (ev is LongtermEvent)
            {
                LongtermEvent myEvent = (LongtermEvent)ev;
                text += " 2";
                long endDateInLong = myEvent.EndDate.ToBinary();
                text += " " + endDateInLong.ToString();
            }
            
            return text;
        }

        /* 
         * Method used to read event from file
         * String in file has format: (startDate) (information):term (priority) (eventType) (endDate) (frequency)
         * Event types: 0 - NormalEvent
         *              1 - PeriodicEvent
         *              2 - LongtermEvent
         */

        public Event readFile(string eventString) 
        {
            int index = eventString.IndexOf(' ');
            string date = eventString.Substring(0, index);
            index++;

            long dateInLong = 0;
            long.TryParse(date, out dateInLong);
            DateTime dateFromFile = DateTime.FromBinary(dateInLong);

            string information = eventString.Substring(index, eventString.IndexOf(":term") - index);
            index += information.Length + 6; // :term + " " gives 6 chars

            int priorValue = 0;
            int.TryParse(eventString.ElementAt(index).ToString(), out priorValue);
            bool priority = priorValue == 1;
            index += 2; // priority + " "

            string eventType = eventString.ElementAt(index).ToString();
            index += 2; // eventType + " "

            if (eventType == "0") 
            {
                NormalEvent myEvent = new NormalEvent(dateFromFile, information, priority);
                return myEvent;
            }

            else if (eventType == "1")
            {
                string endDate = eventString.Substring(index, eventString.IndexOf(' ', index) - index);
                index += endDate.Length + 1;

                long endDateInLong = 0;
                long.TryParse(endDate, out endDateInLong);
                DateTime endDateFromFile = DateTime.FromBinary(endDateInLong);

                string frequency = eventString.Substring(index, eventString.Length - index);
                
                TimeSpan frequencyFromFile;
                TimeSpan.TryParse(frequency, out frequencyFromFile);
                PeriodicEvent myEvent = new PeriodicEvent(dateFromFile, information, priority, endDateFromFile, frequencyFromFile);
                return myEvent;
            }

            else if (eventType == "2")
            {
                string endDate = eventString.Substring(index, eventString.Length - index);
                
                long endDateInLong = 0;
                long.TryParse(endDate, out endDateInLong);
                DateTime endDateFromFile = DateTime.FromBinary(endDateInLong);

                LongtermEvent myEvent = new LongtermEvent(dateFromFile, information, priority, endDateFromFile);
                return myEvent;
            }
            return null;
        }
    }
}
