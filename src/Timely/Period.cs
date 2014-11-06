using System;
using System.Collections;
using System.Diagnostics;
using System.Text;

namespace Timely
{
    [DebuggerDisplay("Period: {ToHumanReadableString(),nq}")]
    public class Period : IEquatable<Period>
    {
        public Period(uint days, uint hours, uint minutes, uint seconds, uint milliseconds)
        {
            Days = days;
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            Milliseconds = milliseconds;
        }

        public uint Days { get; private set; }
        public uint Hours { get; private set; }
        public uint Minutes { get; private set; }
        public uint Seconds { get; private set; }
        public uint Milliseconds { get; private set; }

        public string ToHumanReadableString()
        {
            if (Equals(Empty())) return "Empty";

            var builder = new StringBuilder();

            Action<uint, string> addToBuilder = (amount, identifier) =>
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

        private IStructuralEquatable GetStructuralEquatable()
        {
            return Tuple.Create(Days, Hours, Minutes, Seconds, Milliseconds);
        }

        public static Period Empty()
        {
            return new Period(0, 0, 0, 0, 0);
        }
    }
}