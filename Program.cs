using System;

namespace SpaceLaunch
{
    class Program
    {
        static void Main(string[] args)
        {
            CsvReader reader = new CsvReader("D:\\SpaceLaunch\\SpaceLaunch\\testData.csv");
            reader.printData();
        }
    }
}
