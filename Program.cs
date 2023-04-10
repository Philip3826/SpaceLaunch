using System;
using System.IO;
namespace SpaceLaunch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to Space Launch Calculator");
            Console.WriteLine("Please input the full path of a csv file containing the weather report for the month!");
            string filePathInput = Console.ReadLine();
            if (!File.Exists(filePathInput) || Path.GetExtension(filePathInput) != ".csv")
            {
                Console.WriteLine("The provided path is not a valid one!");
                return;
            }
            Console.WriteLine();
            CsvReader reader = new CsvReader(filePathInput);
            string filePathOutput = Path.GetDirectoryName(filePathInput) + "\\WeatherReport.csv";
            CsvWriter csvWriter = new CsvWriter(reader.GetRawDataRows, filePathOutput);

            DataAnalyzer dataAnalyzer = new DataAnalyzer(reader.GetRawDataColumns.GetRange(1, reader.GetRawDataColumns.Count - 1));
            int bestDay = dataAnalyzer.CalculateBestLaunchDay();

            Console.WriteLine("Please provide email address(gmail) and password(See README for instructions) of the sender:");
            Console.Write("Email:");
            string senderAddress = Console.ReadLine();
            Console.Write("Password:");
            string senderPassword = Console.ReadLine();
            Console.WriteLine("Please provide the email of the receiver:");
            string receiverAddress = Console.ReadLine();
            EmailSender emailSender = new EmailSender(senderAddress, senderPassword,receiverAddress,filePathOutput,bestDay);
            try
            {
                emailSender.Send();
            }
            catch   (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}