using System;
using System.Collections.Generic;
using System.Text;

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
            }catch(ArgumentException e)
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
            this.Humidity = int.Parse(rawData[3]);
            this.Precipitation = int.Parse(rawData[4]);
            if (rawData[5] != "Yes" && rawData[5] != "No") throw new ArgumentException("Lightning field is not a yes or no");
            if (rawData[5] == "Yes") this.Lightning = true;
            this.CloudType = rawData[6];
        }
        private void ValidateLaunchDate()
        {
            if (Temperature < 2 || Temperature > 31) return;
            if (WindSpeed > 10 || Humidity >= 60) return;
            if (Precipitation == 0 || !Lightning) return;
            if (CloudType == "Cumulus" || CloudType == "Nimbus") return;

            ValidLaunchDate = true;
        }
    }
}
