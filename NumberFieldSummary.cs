using System.Collections.Generic;
using System.Linq;

namespace SpaceLaunch
{
    class NumberFieldSummary
    {
        public string FieldName { get; private set; } = "";
        public int MinimalValue { get; private set; } = int.MinValue;
        public int MaximumValue { get; private set; } = int.MaxValue;
        public double AverageValue { get; private set; } = 0;
        public double MedianValue { get; private set; } = 0;
        public int BestLaunchDay { get; private set; } = 0;
        private List<int> values;
        public List<int> Values => values;
        public NumberFieldSummary(List<int> values, string name, int lowerBound, int upperBound)
        {
            this.values = values;
            this.FieldName = name;

            CalculateSummary();
            CalculateBestLaunchDay(lowerBound, upperBound);
        }

        private void CalculateSummary()
        {
            List<int> copyValues = values;
            copyValues.Sort();
            MinimalValue = copyValues[0];
            MaximumValue = copyValues.Last();
            AverageValue = copyValues.Sum() / copyValues.Count;

            if (copyValues.Count % 2 == 0)
            {
                MedianValue = copyValues[copyValues.Count / 2] + copyValues[(copyValues.Count / 2) - 1];
            }
            else MedianValue = copyValues[copyValues.Count / 2];
        }
        private void CalculateBestLaunchDay(int lowerBound, int upperBound)
        {
            int currentLowest = int.MinValue;
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i] > lowerBound && values[i] < upperBound && values[i] < currentLowest)
                {
                    currentLowest = values[i];
                    BestLaunchDay = i + 1;
                }
            }
        }

    }
}
