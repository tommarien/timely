using NUnit.Framework;
using Shouldly;

namespace Timely.Tests
{
    [TestFixture]
    public class When_checking_for_equality
    {
        [Test]
        public void it_behaves_correctly_with_equal_values()
        {
            var period1 = 1000.Milliseconds();
            var period2 = 1.Seconds();

            period1.ShouldBe(period2);
        }

        [Test]
        public void it_behaves_correctly_with_equal_values_complex()
        {
            var period1 = new Period(0, 0, 0, 1, 1000);
            var period2 = 2.Seconds();

            period1.ShouldBe(period2);
        }

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