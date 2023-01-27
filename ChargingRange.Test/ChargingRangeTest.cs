using System;
using System.Collections.Generic;
using Xunit;

namespace ChargingRange.Test
{
    public class ChargingRangeTest
    {

        [Fact]
        public void TestSampleRange()
        {
            List<int> sampleRange = new List<int>() { 4, 5 };
            string rangeReport = ChargingRange.GetRangeReport(sampleRange);

            Assert.True(rangeReport == "4-5, 2");
        }

    }
}