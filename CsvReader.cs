using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.FileIO; 

namespace SpaceLaunch
{
    class CsvReader
    {
        private string filePath;
        private TextFieldParser parser;
        private List<List<string>> extractedRawData;
        public List<List<string>> GetRawData => extractedRawData;

        public CsvReader(string filePath)
        {
            this.filePath = filePath; // assume filePath is already validated
            this.parser = new TextFieldParser(filePath);
            this.parser.TextFieldType = FieldType.Delimited;
            this.parser.SetDelimiters(",");
            ExtractData();
        }

        private void ExtractData()
        {
            extractedRawData = new List<List<string>>();

            string[] days = parser.ReadFields();
            int numberOfColumns = days.Length;
            extractedRawData.Add(new List<string>(days));

            for(int i = 0; i < numberOfColumns; i++)
            {
                extractedRawData.Add(new List<string>());
            }

            while(!parser.EndOfData)
            {
                string[] row = parser.ReadFields();
                for(int i = 1; i < numberOfColumns; i++)
                {
                    extractedRawData[i].Add(row[i]);
                }
            }

            parser.Close();
        }

        public void printData()
        {
            for(int i = 0; i < extractedRawData.Count; i++)
            {
                for(int j = 0; j < extractedRawData[i].Count; j++)
                {
                    Console.Write(extractedRawData[i][j] + ",");
                }
                Console.WriteLine();
            }
        }
        
    }
}
