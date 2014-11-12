using System;
using NUnit.Framework;
using Shouldly;

namespace Timely.Tests
{
    [TestFixture]
    public class When_converting_to_timespan
    {
        [Test]
        public void it_converts_the_days()
        {
            Period period = 2000.Days();

            TimeSpan timeSpan = period.ToTimeSpan();

            timeSpan.ShouldBe(new TimeSpan(2000, 0, 0, 0, 0));
        }

        [Test]
        public void it_converts_the_hours()
        {
            Period period = 2000.Hours();

            TimeSpan timeSpan = period.ToTimeSpan();

            timeSpan.ShouldBe(new TimeSpan(0, 2000, 0, 0, 0));
        }

        [Test]
        public void it_converts_the_milliseconds()
        {
            Period period = 2000.Milliseconds();

            TimeSpan timeSpan = period.ToTimeSpan();

            timeSpan.ShouldBe(new TimeSpan(0, 0, 0, 0, 2000));
        }

        [Test]
        public void it_converts_the_minutes()
        {
            Period period = 2000.Minutes();

            TimeSpan timeSpan = period.ToTimeSpan();

            timeSpan.ShouldBe(new TimeSpan(0, 0, 2000, 0, 0));
        }

        [Test]
        public void it_converts_the_seconds()
        {
            Period period = 2000.Seconds();

            TimeSpan timeSpan = period.ToTimeSpan();

            timeSpan.ShouldBe(new TimeSpan(0, 0, 0, 2000, 0));
        }
    }
}