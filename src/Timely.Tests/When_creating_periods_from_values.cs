using NUnit.Framework;
using Shouldly;

namespace Timely.Tests
{
    [TestFixture]
    public class When_creating_periods_from_values
    {
        [Test]
        public void it_retains_the_amount_of_days()
        {
            Period period = 1000.Days();

            period.Days.ShouldBe(1000);
        }

        [Test]
        public void it_retains_the_amount_of_hours()
        {
            Period period = 1000.Hours();

            period.Hours.ShouldBe(1000);
        }

        [Test]
        public void it_retains_the_amount_of_milliseconds()
        {
            Period period = 1000.Milliseconds();

            period.Milliseconds.ShouldBe(1000);
        }

        [Test]
        public void it_retains_the_amount_of_minutes()
        {
            Period period = 1000.Minutes();

            period.Minutes.ShouldBe(1000);
        }

        [Test]
        public void it_retains_the_amount_of_seconds()
        {
            Period period = 1000.Seconds();

            period.Seconds.ShouldBe(1000);
        }
    }
}