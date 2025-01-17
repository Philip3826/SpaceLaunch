﻿using System;
using System.IO;
using Newtonsoft.Json;
using SpaceLaunch.Classes;
using SpaceLaunch.CsvWorkers;
namespace SpaceLaunch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to Space Launch Calculator");

            string filePathInput = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.csv");
            if (!File.Exists(filePathInput) || Path.GetExtension(filePathInput) != ".csv")
            {
                Console.WriteLine("The provided path is not a valid one!");
                return;
            }
            Console.WriteLine();
            CsvReader reader = new CsvReader(filePathInput);
            if (!reader.ValidateFieldNames())
            {
                Console.WriteLine("Invalid Fields in the csv file!");
                return;
            }
            string filePathOutput = Path.GetDirectoryName(filePathInput) + "\\WeatherReport.csv";
            CsvWriter csvWriter = new CsvWriter(reader.GetRawDataRows, filePathOutput);

            DataAnalyzer dataAnalyzer = new DataAnalyzer(reader.GetRawDataColumns.GetRange(1, reader.GetRawDataColumns.Count - 1));
            int bestDay = dataAnalyzer.CalculateBestLaunchDay();

            var jsonOutput = new
            {
                bestDay,
                dateGenerated = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
            };

            RegionalEntry entry1 = new RegionalEntry { Temperature = 25, Region = "North Europe" };
            RegionalEntry entry2 = new RegionalEntry { Temperature = 18, Region = "South Europe"};
            double temperatureDifference = entry1.Temperature - entry2.Temperature;
            Console.WriteLine($"Temperature difference between {entry1.Region} and {entry2.Region}: {temperatureDifference}°C");

            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BestLaunchDay.json");
            File.WriteAllText(jsonFilePath, JsonConvert.SerializeObject(jsonOutput, Formatting.Indented));
            Console.WriteLine($"JSON file generated at: {jsonFilePath}");

            //Console.WriteLine("Please provide email address(gmail) and password(See README for instructions) of the sender:");
            //Console.Write("Email:");
            //string senderAddress = Console.ReadLine();
            //Console.Write("Password:");
            //string senderPassword = Console.ReadLine();
            //Console.WriteLine("Please provide the email of the receiver:");
            //string receiverAddress = Console.ReadLine();
            //EmailSender emailSender = new EmailSender(senderAddress, senderPassword, receiverAddress, filePathOutput, bestDay);
            //try
            //{
            //    emailSender.Send();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }
    }
}