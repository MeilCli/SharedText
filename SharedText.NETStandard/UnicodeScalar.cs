using System;
using System.Collections.Generic;
using System.Text;

namespace SharedText.NETStandard
{
    /// <summary>
    /// Represents a 24-bit Unicode scalar value.
    /// A scalar value is any value in the range [U+0000..U+D7FF] or [U+E000..U+10FFFF].
    /// This struct is temporary implementation, because use Corefxlab implement.
    /// </summary>
    public readonly struct UnicodeScalar : IComparable<UnicodeScalar>, IEquatable<UnicodeScalar>
    {
        public static bool IsValidScalar(uint value)
            => value <= 0xD7FFU || (0xE000U <= value && value <= 0x10FFFFU);

        public readonly uint Value;

        public UnicodeScalar(char @char)
        {
            if (char.IsLowSurrogate(@char))
            {
                throw new ArgumentOutOfRangeException("value must not be low surrogate char");
            }

            Value = @char;
        }

        public UnicodeScalar(uint value)
        {
            if (IsValidScalar(value) == false)
            {
                throw new ArgumentOutOfRangeException("value must be in range [U+0000..U+D7FF] or [U+E000..U+10FFFF]");
            }

            Value = value;
        }

        public static explicit operator UnicodeScalar(char @char) => new UnicodeScalar(@char);

        public static explicit operator UnicodeScalar(uint value) => new UnicodeScalar(value);

        public static explicit operator char(UnicodeScalar value) => checked((char)value.Value);

        public static explicit operator uint(UnicodeScalar value) => value.Value;

        public static bool operator ==(UnicodeScalar a, UnicodeScalar b) => (a.Value == b.Value);

        public static bool operator !=(UnicodeScalar a, UnicodeScalar b) => (a.Value != b.Value);

        public static bool operator <(UnicodeScalar a, UnicodeScalar b) => (a.Value < b.Value);

        public static bool operator <=(UnicodeScalar a, UnicodeScalar b) => (a.Value <= b.Value);

        public static bool operator >(UnicodeScalar a, UnicodeScalar b) => (a.Value > b.Value);

        public static bool operator >=(UnicodeScalar a, UnicodeScalar b) => (a.Value >= b.Value);

        public bool Equals(UnicodeScalar other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (obj is UnicodeScalar other)
            {
                return Equals(other);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (int)Value;
        }

        public int CompareTo(UnicodeScalar other)
        {
            return Value.CompareTo(other.Value);
        }

        /// <summary>
        /// Returns the number of UTF-16 code units (<see cref="char"/>s) required to represent this scalar.
        /// Scalars in the range [U+0000..U+FFFF] require one UTF-16 code unit.
        /// Scalars in the range [U+10000..U+10FFFF] require two UTF-16 code units.
        /// </summary>
        public int Utf16CodeUnitCount {
            get { return Value < 0x10000U ? 1 : 2; }
        }

        /// <summary>
        /// Returns the number of UTF-8 code units (<see cref="byte"/>s) required to represent this scalar.
        /// Scalars in the range [U+0000..U+007F] require one UTF-8 code unit.
        /// Scalars in the range [U+0080..U+07FF] require two UTF-8 code units.
        /// Scalars in the range [U+0800..U+FFFF] require three UTF-8 code unit.
        /// Scalars in the range [U+10000..U+10FFFF] require four UTF-8 code units.
        /// </summary>
        public int Utf8CodeUnitCount {
            get {
                if (Value < 0x80U)
                {
                    return 1;
                }
                else if (Value < 0x800U)
                {
                    return 2;
                }
                else if (Value < 0x10000U)
                {
                    return 3;
                }
                else
                {
                    return 4;
                }
            }
        }

        /// <summary>
        /// Copies the UTF-16 code unit representation of this scalar to an output buffer.
        /// The buffer must be large enough to hold the required number of <see cref="char"/>s.
        /// The <see cref="Utf16CodeUnitCount"/> property gives the required output buffer length.
        /// </summary>
        public void CopyUtf16CodeUnitsTo(Span<char> utf16)
        {

            if (Value < 0x10000U && 1 <= utf16.Length)
            {
                utf16[0] = (char)Value;
            }
            else if (2 <= utf16.Length)
            {
                utf16[0] = (char)(0xD7C0U + (Value >> 10));
                utf16[1] = (char)(0xDC00U | (Value & 0x3FFU));
            }
            else
            {
                throw new ArgumentException(
                    message: "Argument is not long enough to hold output value.",
                    paramName: nameof(utf16));
            }
        }

        /// <summary>
        /// Copies the UTF-8 code unit representation of this scalar to an output buffer.
        /// The buffer must be large enough to hold the required number of <see cref="byte"/>s.
        /// The <see cref="Utf8CodeUnitCount"/> property gives the required output buffer length.
        /// </summary>
        public void CopyUtf8CodeUnitsTo(Span<byte> utf8)
        {
            if (Value < 0x80U && 1 <= utf8.Length)
            {
                utf8[0] = (byte)Value;
            }
            else if (Value < 0x800U && 2 <= utf8.Length)
            {
                utf8[0] = (byte)(0xC0U | (Value >> 6));
                utf8[1] = (byte)(0x80U | (Value & 0x3FU));
            }
            else if (Value < 0x10000U && 3 <= utf8.Length)
            {
                utf8[0] = (byte)(0xE0U | (Value >> 12));
                utf8[1] = (byte)(0x80U | ((Value >> 6) & 0x3FU));
                utf8[2] = (byte)(0x80U | (Value & 0x3FU));
            }
            else if (4 <= utf8.Length)
            {
                utf8[0] = (byte)(0xF0U | (Value >> 18));
                utf8[1] = (byte)(0x80U | ((Value >> 12) & 0x3FU));
                utf8[2] = (byte)(0x80U | ((Value >> 6) & 0x3FU));
                utf8[3] = (byte)(0x80U | (Value & 0x3FU));
            }
            else
            {
                throw new ArgumentException(
                  message: "Argument is not long enough to hold output value.",
                  paramName: nameof(utf8));
            }
        }
    }
}
