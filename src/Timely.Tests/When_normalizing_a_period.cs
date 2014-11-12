using NUnit.Framework;
using Shouldly;

namespace Timely.Tests
{
    [TestFixture]
    public class When_normalizing_a_period
    {
        [Test]
        public void it_normalizes_hours()
        {
            var period = new Period(0, 25, 1, 5, 550);

            Period normalized = period.Normalize();

            normalized.ShouldBe(new Period(1, 1, 1, 5, 550));
        }

        [Test]
        public void it_normalizes_milliseconds()
        {
            var period = new Period(0, 0, 0, 0, 5550);

            Period normalized = period.Normalize();

            normalized.ShouldBe(new Period(0, 0, 0, 5, 550));
        }

        [Test]
        public void it_normalizes_minutes()
        {
            var period = new Period(0, 0, 61, 5, 550);

            Period normalized = period.Normalize();

            normalized.ShouldBe(new Period(0, 1, 1, 5, 550));
        }

        [Test]
        public void it_normalizes_seconds()
        {
            var period = new Period(0, 0, 0, 65, 550);

            Period normalized = period.Normalize();

            normalized.ShouldBe(new Period(0, 0, 1, 5, 550));
        }
    }
}