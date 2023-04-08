using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SpaceLaunch
{
    class CsvReader
    {
        private string filePath;
        private TextFieldParser parser;
        private List<List<string>> extractedRawDataColumns;
        public List<List<string>> GetRawDataColumns => extractedRawDataColumns;
        private List<List<string>> extractedRawDataRows;
        public List<List<string>> GetRawDataRows => extractedRawDataRows;
        public CsvReader(string filePath)
        {
            this.filePath = filePath; // assume filePath is already validated
            
            ExtractDataByColumns(filePath);
            ExtractDataByRows(filePath);
        }

        private void ExtractDataByColumns(string filePath)
        {   
            this.parser = new TextFieldParser(filePath);
            this.parser.TextFieldType = FieldType.Delimited;
            this.parser.SetDelimiters(",");
            extractedRawDataColumns = new List<List<string>>();

            string[] days = parser.ReadFields();
            int numberOfColumns = days.Length;        

            for (int i = 0; i < numberOfColumns; i++)
            {
                extractedRawDataColumns.Add(new List<string>());
            }
            for(int i = 0; i < numberOfColumns;i++)
            {
                extractedRawDataColumns[i].Add(days[i]);
            }

            while (!parser.EndOfData)
            {
                string[] row = parser.ReadFields();
                for (int i = 0; i < numberOfColumns; i++)
                {
                    extractedRawDataColumns[i].Add(row[i]);
                }
            }

            parser.Close();
        }
        private void ExtractDataByRows(string filePath)
        {
            this.parser = new TextFieldParser(filePath);
            this.parser.TextFieldType = FieldType.Delimited;
            this.parser.SetDelimiters(",");
            extractedRawDataRows = new List<List<string>>();
            while(!parser.EndOfData)
            {
                string[] rowArray = parser.ReadFields();
                List<string> rowList = new List<string>(rowArray);
               
                extractedRawDataRows.Add(rowList);
            }
            parser.Close();
        }
        public void printData()
        {
            for (int i = 0; i < extractedRawDataRows.Count; i++)
            {
                for (int j = 0; j < extractedRawDataRows[i].Count; j++)
                {
                    Console.Write(extractedRawDataRows[i][j] + ",");
                }
                Console.WriteLine();
            }
        }

    }
}
