using System;
using System.Collections.Generic;
using Xunit;

namespace ChargingRange.Test
{
    public class ChargingRangeTest
    {
        public static IEnumerable<object[]> RangeData()
        {
            yield return new object[] { new List<int> { 3, 4 }, " (3-4, 2) " };
            yield return new object[] { new List<int> { 2, 3, 4, 7, 8, 9 }, " (2-4, 3)  (7-9, 3) " };
            yield return new object[] { new List<int> { 4, 3, 6, 5, 11, 10, 12 }, " (3-6, 4)  (10-12, 3) " };
            yield return new object[] { new List<int> { 3, 3, 5, 4, 11, 10, 12 }, " (3-5, 3)  (10-12, 3) " };
        }

        public static IEnumerable<object[]> BatteryRangeData()
        {
            yield return new object[] { 
                new ChargingRange.BatteryRange()
                { 
                    startRangeList = new List<int>(){ 3 },
                    endRangeList = new List<int>(){ 4 },
                    countList = new List<int>(){ 2 }
                },
                " (3-4, 2) " 
            };

            yield return new object[] {
                new ChargingRange.BatteryRange()
                {
                    startRangeList = new List<int>(){ 3, 10 },
                    endRangeList = new List<int>(){ 6, 12 },
                    countList = new List<int>(){ 4,3 }
                },
                " (3-6, 4)  (10-12, 3) "
            };
        }

        [Fact]
        public void GetRange_EmptyList_ReturnZero()
        {
            List<int> inputList = new List<int>();
            string range = ChargingRange.GetRange(inputList);
            Assert.True(range == "0");
        }

        [Fact]
        public void GetRange_SingleElement_ReturnElement()
        {
            List<int> inputList = new List<int>() { 2 };
            string range = ChargingRange.GetRange(inputList);
            Assert.True(range == " (2-2, 1) ");
        }

        [Theory]
        [MemberData(nameof(RangeData))]
        public void GetRange_InputList_ReturnRange(List<int> inputList, string expectedRange)
        {
            string range = ChargingRange.GetRange(inputList);
            Assert.True(range == expectedRange);
        }

        [Fact]
        public void GetRange_UnsortedList_ReturnRange()
        {
            List<int> inputList = new List<int>() { 4, 3, 6, 5, 11, 10, 12 };
            string range = ChargingRange.GetRange(inputList);
            Assert.True(range == " (3-6, 4)  (10-12, 3) ");
        }

        [Theory]
        [MemberData(nameof(BatteryRangeData))]
        public void GetFormattedRangeCSV_BatteryRange_ReturnRangeCSV(ChargingRange.BatteryRange batteryRange, string expectedRangeCSV)
        {
            string rangeCSV = ChargingRange.GetFormattedRangeCSV(batteryRange);
            Assert.True(rangeCSV == expectedRangeCSV);
        }
    }
}