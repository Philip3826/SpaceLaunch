﻿using System.Collections.Generic;

namespace SpaceLaunch.Classes
{
    class StringFieldSummary
    {
        public string FieldName { get; private set; } = "";
        public int BestLaunchDate { get; private set; } = 0;
        private List<string> values;

        public StringFieldSummary(List<string> values, string name)
        {
            this.values = values;
            FieldName = name;
            CalculateBestLaunchDate();
        }

        private void CalculateBestLaunchDate()
        {
            switch (FieldName)
            {
                case "Lightning":
                    {
                        for (int i = 0; i < values.Count; i++)
                        {
                            if (values[i] == "No") { BestLaunchDate = i + 1; break; }
                        }
                    }
                    break;
                case "Clouds":
                    {
                        for (int i = 0; i < values.Count; i++)
                        {
                            if (values[i] != "Cumulus" && values[i] != "Nimbus") { BestLaunchDate = i + 1; break; }
                        }
                    }
                    break;
                default: break;
            }
        }
    }
}
