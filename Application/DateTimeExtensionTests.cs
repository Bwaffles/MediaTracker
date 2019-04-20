using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Application
{
    [TestClass]
    public class DateTimeExtensionTests
    {
        [TestClass]
        public class PrettyDateTests
        {
            private void AssertPrettyDate(int daysAgo, string message)
            {
                DateTime? date = DateTime.Today.AddDays(daysAgo * -1);
                date.PrettyDate().Should().Be(message);
            }

            [TestMethod]
            public void NullSource_ReturnsUnknown()
            {
                DateTimeExtension.PrettyDate(null).Should().Be("Unknown");
            }

            [TestMethod]
            public void Yesterday()
            {
                AssertPrettyDate(1, "Yesterday");
            }

            [TestMethod]
            public void DaysAgo()
            {
                AssertPrettyDate(6, "6 days ago");
            }

            [TestMethod]
            public void WeeksAgo()
            {
                AssertPrettyDate(7, "1 week ago");
            }

            [TestMethod]
            public void MultipleWeeksAgo()
            {
                AssertPrettyDate(23, "3 weeks ago");
            }
        }
    }
}
