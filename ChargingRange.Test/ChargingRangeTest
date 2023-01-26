using System;
using Xunit;

namespace ChargingRange.Test
{
    public class ChargingRangeTest
    {
    
    [Fact]
    public void TestSampleRange()
    {
        int[] sampleRange = new int[2] { 4, 5 };
        string rangeReport = ChargingRange.GetRangeReport(sampleRange);

        Assert.True(rangeReport == "4-5, 2");
    }
    
    }
}
