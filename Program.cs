using System;
using System.Collections.Generic;

namespace SpaceLaunch
{
    class Program
    {
        static void Main(string[] args)
        {
            CsvReader reader = new CsvReader("C:\\Users\\Radena\\Source\\Repos\\SpaceLaunch\\testData.csv");
            reader.printData();
            //some changes here 
            CsvWriter writer = new CsvWriter(reader.GetRawDataRows, "C:\\Users\\Radena\\Source\\Repos\\SpaceLaunch\\WeatherReport.csv");
            DataAnalyzer dataAnalyzer = new DataAnalyzer(reader.GetRawDataColumns.GetRange(1, reader.GetRawDataColumns.Count - 1));
            Console.WriteLine(dataAnalyzer.CalculateBestLaunchDay());
            
        }
    }
}
