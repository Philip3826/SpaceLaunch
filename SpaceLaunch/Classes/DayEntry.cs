﻿using System;
using System.Collections.Generic;

namespace SpaceLaunch.Classes
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
            Date = int.Parse(rawData[0]);
            if (Date < 1 || Date > 31) throw new ArgumentException("An invalid Date found in the data");
            Temperature = int.Parse(rawData[1]);
            WindSpeed = int.Parse(rawData[2]);
            if (WindSpeed < 0) throw new ArgumentException("Wind speed that is less than 0m/s found in the data");
            Humidity = int.Parse(rawData[3]);
            if (Humidity < 0 || Humidity > 100) throw new ArgumentException("Humidity that is not a percentage found in the data");
            Precipitation = int.Parse(rawData[4]);
            if (Precipitation < 0 || Precipitation > 100) throw new ArgumentException("Precipitation that is not a percentage found in the data");
            if (rawData[5] != "Yes" && rawData[5] != "No") throw new ArgumentException("Lightning field that is not yes/no found in the data");
            if (rawData[5] == "Yes") Lightning = true;
            CloudType = rawData[6];
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
