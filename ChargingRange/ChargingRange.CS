using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargingRange
{
    class ChargingRange
    {
        public static String GetRangeReport(List<int> range)
        {
            range.Sort();

            String report = String.Format("{0}-{1}, {2}", range.First(), range.Last(), range.Count);

            return report;
        }
    }
}
