using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceLaunch
{
    class DataAnalyzer
    {
        List<DayEntry> dayEntries;

        public DataAnalyzer(List<List<string>> rawData)
        {
            dayEntries = new List<DayEntry>();
            foreach (List<string> item in rawData)
            {
                DayEntry tmpDayEntry = new DayEntry(item);
                if (tmpDayEntry.ValidData) { dayEntries.Add(tmpDayEntry); }
            }
        }

        public int CalculateBestLaunchDay()
        {
            DayEntry currentBestDay = dayEntries[0];
            foreach(DayEntry dayEntry in dayEntries) 
            {
                if(CompareDays(currentBestDay, dayEntry))
                {
                    currentBestDay = dayEntry;
                }
            }

            if (currentBestDay.ValidLaunchDate) return currentBestDay.Date;
            return 0;
        }

        private bool CompareDays(DayEntry currentBest, DayEntry currentDay) 
        {
            if(currentDay.ValidLaunchDate)
            {
                if (currentDay.WindSpeed < currentBest.WindSpeed) return true;
                else if (currentDay.WindSpeed == currentBest.WindSpeed && currentDay.Humidity < currentBest.Humidity) return true;

                return false;
            }
            return false;
        }
    }
}
