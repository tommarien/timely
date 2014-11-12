namespace Timely
{
    public static class PeriodFactoryExtensions
    {
        public static Period Milliseconds(this int amount)
        {
            return new Period(0, 0, 0, 0, amount);
        }

        public static Period Seconds(this int amount)
        {
            return new Period(0, 0, 0, amount, 0);
        }

        public static Period Minutes(this int amount)
        {
            return new Period(0, 0, amount, 0, 0);
        }

        public static Period Hours(this int amount)
        {
            return new Period(0, amount, 0, 0, 0);
        }

        public static Period Days(this int amount)
        {
            return new Period(amount, 0, 0, 0, 0);
        }
    }
}