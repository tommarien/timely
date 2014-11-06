using NUnit.Framework;
using Shouldly;

namespace Timely.Tests
{
    [TestFixture]
    public class When_creating_a_period
    {
        [Test]
        public void it_retains_the_amount_of_days()
        {
            var period = new Period(1, 0, 0, 0, 0);

            period.Days.ShouldBe(1U);
        }

        [Test]
        public void it_retains_the_amount_of_hours()
        {
            var period = new Period(0, 10, 0, 0, 0);

            period.Hours.ShouldBe(10U);
        }

        [Test]
        public void it_retains_the_amount_of_milliseconds()
        {
            var period = new Period(0, 0, 0, 0, 595);

            period.Milliseconds.ShouldBe(595U);
        }

        [Test]
        public void it_retains_the_amount_of_minutes()
        {
            var period = new Period(0, 0, 30, 0, 0);

            period.Minutes.ShouldBe(30U);
        }

        [Test]
        public void it_retains_the_amount_of_seconds()
        {
            var period = new Period(0, 0, 0, 45, 0);

            period.Seconds.ShouldBe(45U);
        }
    }
}