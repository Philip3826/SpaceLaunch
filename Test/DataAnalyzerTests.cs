using System.Collections.Generic;
using SpaceLaunch.Classes;
using Xunit;

namespace Test
{
    public class DataAnalyzerTests
    {
        [Fact]
        public void CalculateBestLaunchDay_ReturnsZero_WhenNoValidLaunchDate()
        {
            // Arrange
            var rawData = new List<List<string>>
                {
                    new List<string> { "20230101", "20", "5", "50", "0", "false", "Cumulus", "false", "true" },
                    new List<string> { "20230102", "22", "3", "40", "0", "false", "Cumulus", "false", "true" }
                };
            var analyzer = new DataAnalyzer(rawData);

            // Act
            int bestLaunchDay = analyzer.CalculateBestLaunchDay();

            // Assert
            Assert.Equal(0, bestLaunchDay);
        }

        [Fact]
        public void CalculateBestLaunchDay_ReturnsZero_WhenEmptyData()
        {
            // Arrange
            var rawData = new List<List<string>>();
            var analyzer = new DataAnalyzer(rawData);

            // Act
            int bestLaunchDay = analyzer.CalculateBestLaunchDay();

            // Assert
            Assert.Equal(0, bestLaunchDay);
        }

        [Fact]
        public void CalculateBestLaunchDay_ReturnsZero_WhenAllInvalidData()
        {
            // Arrange
            var rawData = new List<List<string>>
                {
                    new List<string> { "20230101", "20", "5", "50", "0", "false", "Cumulus", "false", "false" },
                    new List<string> { "20230102", "22", "3", "40", "0", "false", "Cumulus", "false", "false" }
                };
            var analyzer = new DataAnalyzer(rawData);

            // Act
            int bestLaunchDay = analyzer.CalculateBestLaunchDay();

            // Assert
            Assert.Equal(0, bestLaunchDay);
        }

        [Fact]
        public void CalculateBestLaunchDay_ReturnsFirstDay_WhenMultipleBestDays()
        {
            // Arrange
            var rawData = new List<List<string>>
            {
                new List<string> { "01", "20", "3", "40", "0", "No", "Stratus", "true" },
                new List<string> { "02", "20", "3", "40", "0", "No", "Stratus", "true" }
            };
            var analyzer = new DataAnalyzer(rawData);

            // Act
            int bestLaunchDay = analyzer.CalculateBestLaunchDay();

            // Assert
            Assert.Equal(1, bestLaunchDay);
        }
    }
}
