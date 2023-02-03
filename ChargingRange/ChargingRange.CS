using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingRange
{
	public class ChargingRange
	{
		public struct BatteryRange
		{
			public List<int> startRangeList;
			public List<int> endRangeList;
			public List<int> countList;
		}

		public static string GetRange(List<int> inputList)
		{
			if (inputList.Count == 0) return "0";

			inputList = GetSortedList(inputList);

			inputList = GetDistinctList(inputList);

			BatteryRange batteryRange =  GenerateRange(inputList);

			string range = GetFormattedRangeCSV(batteryRange);

			return range;
		}

        private static List<int> GetSortedList(List<int> inputList)
        {
			inputList.Sort();
			return inputList;
        }

		private static List<int> GetDistinctList(List<int> inputList)
		{
			List<int> distinctList = inputList.Distinct().ToList();
			return distinctList;
		}

		private static BatteryRange GenerateRange(List<int> inputList)
        {
			List<int> startRangeList = new List<int>();
			List<int> endRangeList = new List<int>();
			List<int> countList = new List<int>();

			int count = 1;
			startRangeList.Add(inputList[0]);

			for (int i = 0; i < inputList.Count; i++)
			{
				if (i != (inputList.Count - 1))
				{
					if (inputList[i + 1] - inputList[i] == 1)
					{
						count++;
					}
					else
					{
						endRangeList.Add(inputList[i]);
						countList.Add(count);
						count = 1;
						startRangeList.Add(inputList[i + 1]);
					}
				}
				else
				{
					endRangeList.Add(inputList[i]);
					countList.Add(count);
				}
			}

			BatteryRange batteryRange = new BatteryRange()
			{
				startRangeList = startRangeList,
				endRangeList = endRangeList,
				countList = countList
			};

			return batteryRange;
		}

		public static string GetFormattedRangeCSV(BatteryRange batteryRange)
		{
			string formattedString = "";

			for (int index = 0; index < batteryRange.startRangeList.Count; index++)
			{
				formattedString += String.Format(" ({0}-{1}, {2}) ",
								   batteryRange.startRangeList[index], batteryRange.endRangeList[index], batteryRange.countList[index]);
			}

			return formattedString;
		}
    }
}
