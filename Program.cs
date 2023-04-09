using System;
using System.Net;
using System.Net.Mail;
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
            int day = dataAnalyzer.CalculateBestLaunchDay();

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("senderLaunchDate@mail.bg");
            mailMessage.To.Add(new MailAddress("receiverLaunchDate@mail.bg"));
            mailMessage.Subject = "Test weather report";
            mailMessage.Body = "Best Launch Day: " + day.ToString();

            // Attachment attachment = new Attachment("C:\\Users\\Radena\\Source\\Repos\\SpaceLaunch\\WeatherReport.csv");
            // mailMessage.Attachments.Add(attachment);
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.mail.bg";
                smtpClient.Port = 25;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("senderlaunchdate@mail.bg", "014426045fFF");
                smtpClient.Send(mailMessage);
                Console.WriteLine("Sent mail!");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());

            }
        }
    }
}