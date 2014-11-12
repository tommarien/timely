using System;
using System.Collections;
using System.Diagnostics;
using System.Text;

namespace Timely
{
    [DebuggerDisplay("Period: {ToString(),nq}")]
    public class Period : IEquatable<Period>
    {
        private const int MillisecondsPerSecond = 1000;
        private const int SecondsPerMinute = 60;
        private const int MinutePerHour = SecondsPerMinute;
        private const int HoursPerDay = 24;

        public Period(int days, int hours, int minutes, int seconds, int milliseconds, bool isNegative = false)
        {
            if (days < 0)
                throw new ArgumentOutOfRangeException("days", "Days should be a positive integer, you can use negate if you want it to be negative");

            if (hours < 0)
                throw new ArgumentOutOfRangeException("hours", "Hours should be a positive integer, you can use negate if you want it to be negative");

            if (minutes < 0)
                throw new ArgumentOutOfRangeException("minutes", "Minutes should be a positive integer, you can use negate if you want it to be negative");

            if (seconds < 0)
                throw new ArgumentOutOfRangeException("seconds", "Seconds should be a positive integer, you can use negate if you want it to be negative");

            if (milliseconds < 0)
                throw new ArgumentOutOfRangeException("milliseconds",
                    "Milliseconds should be a positive integer, you can use negate if you want it to be negative");

            Days = days;
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            Milliseconds = milliseconds;

            IsNegative = isNegative;
        }

        public int Days { get; private set; }
        public int Hours { get; private set; }
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }
        public int Milliseconds { get; private set; }
        public bool IsNegative { get; private set; }

        public bool Equals(Period other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return GetStructuralEquatable().Equals(other.GetStructuralEquatable());
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Period);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = GetType().GetHashCode();

                hashCode = (hashCode*31) ^ GetStructuralEquatable().GetHashCode();

                return hashCode;
            }
        }

        public Period Normalize()
        {
            int milliseconds = Milliseconds;
            int seconds = Seconds;
            int minutes = Minutes;
            int hours = Hours;
            int days = Days;

            if (milliseconds > MillisecondsPerSecond)
                seconds += Math.DivRem(milliseconds, MillisecondsPerSecond, out milliseconds);

            if (seconds > SecondsPerMinute)
                minutes += Math.DivRem(seconds, SecondsPerMinute, out seconds);

            if (minutes > MinutePerHour)
                hours += Math.DivRem(minutes, MinutePerHour, out minutes);

            if (hours > HoursPerDay)
                days += Math.DivRem(hours, HoursPerDay, out hours);

            return new Period(days, hours, minutes, seconds, milliseconds);
        }

        public override string ToString()
        {
            if (Equals(Empty())) return "Empty";

            var builder = new StringBuilder();

            Action<int, string> addToBuilder = (amount, identifier) =>
            {
                if (amount <= 0) return;
                if (builder.Length > 0) builder.Append(" ");
                builder.AppendFormat("{0:F0}{1}", amount, identifier);
            };

            addToBuilder(Days, "d");
            addToBuilder(Hours, "h");
            addToBuilder(Minutes, "m");
            addToBuilder(Seconds, "s");
            addToBuilder(Milliseconds, "ms");

            return builder.ToString();
        }

        private IStructuralEquatable GetStructuralEquatable()
        {
            return Tuple.Create(IsNegative, Days, Hours, Minutes, Seconds, Milliseconds);
        }

        public static Period Empty()
        {
            return new Period(0, 0, 0, 0, 0);
        }

        public TimeSpan ToTimeSpan()
        {
            return new TimeSpan(Days, Hours, Minutes, Seconds, Milliseconds);
        }
    }
}