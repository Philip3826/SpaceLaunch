using System;
using System.Collections.Generic;

namespace SpaceLaunch
{
    class Program
    {
        static void Main(string[] args)
        {
            CsvReader reader = new CsvReader("D:\\SpaceLaunch\\SpaceLaunch\\testData.csv");
            reader.printData();
            //some changes here
            CsvWriter writer = new CsvWriter(reader.GetRawDataRows,"D:\\SpaceLaunch\\SpaceLaunch\\WeatherReport.csv");
            
        }
    }
}
