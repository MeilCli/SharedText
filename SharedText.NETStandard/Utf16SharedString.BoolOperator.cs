using System;
using System.Collections.Generic;
using System.Text;

namespace SharedText.NETStandard
{
    public partial class Utf16SharedString
    {
        public bool Contains(UnicodeScalar unicodeScalar)
        {
            Span<char> span = stackalloc char[unicodeScalar.Utf16CodeUnitCount];
            unicodeScalar.CopyUtf16CodeUnitsTo(span);
            return RawString.AsSpan().Contains(span, StringComparison.Ordinal);
        }

        public bool Contains(string value)
        {
            return RawString.Contains(value);
        }

        public bool StartsWith(UnicodeScalar unicodeScalar)
        {
            Span<char> span = stackalloc char[unicodeScalar.Utf16CodeUnitCount];
            unicodeScalar.CopyUtf16CodeUnitsTo(span);
            return RawString.AsSpan().StartsWith(span, StringComparison.Ordinal);
        }

        public bool StartsWith(string value)
        {
            return RawString.StartsWith(value, StringComparison.Ordinal);
        }

        public bool EndsWith(UnicodeScalar unicodeScalar)
        {
            Span<char> span = stackalloc char[unicodeScalar.Utf16CodeUnitCount];
            unicodeScalar.CopyUtf16CodeUnitsTo(span);
            return RawString.AsSpan().EndsWith(span, StringComparison.Ordinal);
        }

        public bool EndsWith(string value)
        {
            return RawString.EndsWith(value, StringComparison.Ordinal);
        }
    }
}
