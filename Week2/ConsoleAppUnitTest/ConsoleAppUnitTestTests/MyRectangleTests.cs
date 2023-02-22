using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppUnitTest.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppUnitTest.Program.Tests
{
    [TestClass()]
    public class MyRectangleTests
    {
        [TestMethod()]
        public void Given_w6_h8_When_GetArea_Then_48()
        {
            var r = new MyRectangle { Width = 6, Height = 8 };
            double actual = r.GetArea();
            double expected = 48;
            Assert.AreEqual(expected, actual);
        }

        // [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        [DataRow(12, 5, 60)]
        [DataRow( 6, 9, 54)] //僅某型別可用, decimal 不可用
        [DataTestMethod ()]
        public void GetAreaDataTest(double width, double height, double expected)
        { 
            var give = new MyRectangle { Width = width, Height = height };
            var actual = give.GetArea();
            Assert.AreEqual(expected, actual);
        }
        /*
        private static IEnumerable <object[]> GetData()
        {
            yield return new object[] {  6, 9, 54 };
            yield return new object[] { 12, 5, 60 };
            yield return new object[] { 17, 3, 51 };
        }*/
    }
}