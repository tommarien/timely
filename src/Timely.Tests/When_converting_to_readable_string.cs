using NUnit.Framework;
using Shouldly;

namespace Timely.Tests
{
    [TestFixture]
    public class When_converting_to_readable_string
    {
        [Test]
        public void it_converts_the_amount_of_days_to_human_readable_format()
        {
            var oneDay = new Period(1, 0, 0, 0, 0);

            oneDay.ToString().ShouldBe("1d");
        }

        [Test]
        public void it_converts_the_amount_of_hours_to_human_readable_format()
        {
            var aPeriodOf24Hours = new Period(0, 24, 0, 0, 0);

            aPeriodOf24Hours.ToString().ShouldBe("24h");
        }

        [Test]
        public void it_converts_the_amount_of_milliseconds_to_human_readable_format()
        {
            var thirtyMinutes = new Period(0, 0, 0, 0, 1500);

            thirtyMinutes.ToString().ShouldBe("1500ms");
        }

        [Test]
        public void it_converts_the_amount_of_minutes_to_human_readable_format()
        {
            var thirtyMinutes = new Period(0, 0, 30, 0, 0);

            thirtyMinutes.ToString().ShouldBe("30m");
        }

        [Test]
        public void it_converts_the_amount_of_seconds_to_human_readable_format()
        {
            var thirtyMinutes = new Period(0, 0, 0, 30, 0);

            thirtyMinutes.ToString().ShouldBe("30s");
        }

        [Test]
        public void it_handles_complex_situations()
        {
            var period = new Period(20, 12, 0, 50, 0);

            period.ToString().ShouldBe("20d 12h 50s");
        }

        [Test]
        public void it_returns_empty_when_everything_is_on_zero()
        {
            Period emptyPeriod = Period.Empty;

            emptyPeriod.ToString().ShouldBe("Empty");
        }
    }
}