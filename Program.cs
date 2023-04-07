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
            List<string> test= new List<string>(){ "Nimbus","Nimbus","Stratus"};
            List<string> light = new List<string>() { "No", "Yes", "No", "Yes" };
            StringFieldSummary cloudsData = new StringFieldSummary(test, "Clouds");
            StringFieldSummary lightningData = new StringFieldSummary(light, "Lightning");
            Console.WriteLine(cloudsData.BestLaunchDate);
            Console.WriteLine(lightningData.BestLaunchDate);
        }
    }
}
