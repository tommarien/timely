using NUnit.Framework;
using Shouldly;

namespace Timely.Tests
{
    [TestFixture]
    public class When_checking_for_equality
    {
        [Test]
        public void it_is_instance_independent()
        {
            var period1 = 10.Milliseconds();
            var period2 = 10.Milliseconds();

            period1.ShouldBe(period2);
            period1.ShouldNotBe(100.Seconds());
        }

        [Test]
        public void it_is_instance_independent_with_operator()
        {
            var period1 = 10.Milliseconds();
            var period2 = 10.Milliseconds();

            (period1 == period2).ShouldBe(true);
            (period1 == 200.Milliseconds()).ShouldBe(false);
        }
    }
}