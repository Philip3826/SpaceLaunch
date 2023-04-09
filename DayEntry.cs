using System;
using System.Collections.Generic;

namespace SpaceLaunch
{
    class DayEntry
    {
        public int Date { get; private set; } = 1;

        public int Temperature { get; private set; } = 0;

        public int WindSpeed { get; private set; } = 0;

        public int Humidity { get; private set; } = 0;

        public int Precipitation { get; private set; } = 0;

        public bool Lightning { get; private set; } = false;

        public string CloudType { get; private set; } = "";

        public bool ValidLaunchDate { get; private set; } = false;
        public bool ValidData { get; private set; } = true;

        public DayEntry(List<string> rawData)
        {
            try
            {
                ParseRawData(rawData);
                ValidateLaunchDate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                ValidData = false;
            }
        }

        private void ParseRawData(List<string> rawData)
        {
            this.Date = int.Parse(rawData[0]);
            if (Date < 1 || Date > 15) throw new ArgumentException("Date is invalid");
            this.Temperature = int.Parse(rawData[1]);
            this.WindSpeed = int.Parse(rawData[2]);
            if (WindSpeed < 0) throw new ArgumentException("Wind speed must be a >= 0 number");
            this.Humidity = int.Parse(rawData[3]);
            if (Humidity < 0 || Humidity > 100) throw new ArgumentException("Humidity is a percentage");
            this.Precipitation = int.Parse(rawData[4]);
            if (Precipitation < 0 || Precipitation > 100) throw new ArgumentException("Precipitation is a percentage");
            if (rawData[5] != "Yes" && rawData[5] != "No") throw new ArgumentException("Lightning field is not a yes or no");
            if (rawData[5] == "Yes") this.Lightning = true;
            this.CloudType = rawData[6];
        }
        private void ValidateLaunchDate()
        {
            if (Temperature < 2 || Temperature > 31) return;
            if (WindSpeed > 10 || Humidity >= 60) return;
            if (Precipitation != 0 || Lightning) return;
            if (CloudType == "Cumulus" || CloudType == "Nimbus") return;

            ValidLaunchDate = true;
        }
    }
}
