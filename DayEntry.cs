using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceLaunch
{
    class DayEntry
    {
        private int date;
        public int Date => date;

        private int temperature;
        public int Temperature => temperature;

        private int windSpeed;
        public int WindSpeed => windSpeed;

        private int humidity;
        public int Humidity => humidity;

        private int precipitation;
        public int Precipitation => precipitation;

        private bool lightning = false;
        public bool Lightning => lightning;

        private string cloudType;
        public string CloudType => cloudType;

        private bool isValidLaunchDate = true;
        public bool ValidLaunchDate => isValidLaunchDate;

        public DayEntry(int date, int temp, int speed, int humidity, int precipitation, string lightning, string cloudType)
        {
            this.date = date;
            this.temperature = temp;
            this.windSpeed = speed;
            this.humidity = humidity;
            this.precipitation = precipitation;
            this.cloudType = cloudType;
            if (lightning == "Yes") this.lightning = true;
            validateLaunchDate();
        }
        
        private void validateLaunchDate()
        {
            if (temperature < 2 || temperature > 31) isValidLaunchDate = false;
            if (windSpeed > 10 || humidity >= 60) isValidLaunchDate = false;
            if (precipitation == 0 || !lightning) isValidLaunchDate = false;
            if (cloudType == "Cumulus" || cloudType == "Nimbus") isValidLaunchDate = false;
        }
    }
}
