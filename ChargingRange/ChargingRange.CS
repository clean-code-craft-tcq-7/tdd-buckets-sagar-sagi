using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingRange
{
    class ChargingRange
    {
		public static string GetRangeReport(List<int> range)
        {
			range.Sort(); //Sorting the list
			List<int> distinctList = range.Distinct().ToList(); // remove the duplicates

			string report = String.Format("{0}-{1}, {2}", distinctList.First(), distinctList.Last(), distinctList.Count);

			return report;
		}

        public static string GetRangeReportFormatted(List<int> range)
        {
			range.Sort(); //Sorting the list
			List<int> distinctList = range.Distinct().ToList(); // remove the duplicates

			List<int> startRangeList = new List<int>();
			List<int> endRangeList = new List<int>();
			List<int> countList = new List<int>();

			int count = 1;
			startRangeList.Add(distinctList[0]);

			for (int i = 0; i < distinctList.Count; i++)
			{
				if (i != (distinctList.Count - 1))
				{
					if (distinctList[i + 1] - distinctList[i] == 1)
					{
						count++;
					}
					else
					{
						endRangeList.Add(distinctList[i]);
						countList.Add(count);
						count = 1;
						startRangeList.Add(distinctList[i + 1]);
					}
				}
				else
				{
					endRangeList.Add(distinctList[i]);
					countList.Add(count);
				}
			}

			string report = GetFormattedString(startRangeList, endRangeList, countList);

            return report;
        }

        private static string GetFormattedString(List<int> startRangeList, List<int> endRangeList, List<int> countList)
        {
			string formattedString = String.Format("{0,-10} {1,-10} {2,-10}\n\n", "StartRange", "EndRange", "Readings");

			for (int index = 0; index < startRangeList.Count; index++)
            {
				formattedString += String.Format("{0,-10} {1,-10} {2,-10}\n",
								   startRangeList[index], endRangeList[index], countList[index]);
			}

			return formattedString; 
		}
    }
}
