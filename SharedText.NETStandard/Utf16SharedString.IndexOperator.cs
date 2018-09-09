using System;
using System.Collections.Generic;
using System.Text;

namespace SharedText.NETStandard
{
    public partial class Utf16SharedString
    {
        public int IndexOf(UnicodeScalar unicodeScalar)
        {
            Span<char> span = stackalloc char[unicodeScalar.Utf16CodeUnitCount];
            unicodeScalar.CopyUtf16CodeUnitsTo(span);
            return RawString.AsSpan().IndexOf(span, StringComparison.Ordinal);
        }

        public int IndexOf(UnicodeScalar unicodeScalar, int startIndex)
        {
            Span<char> span = stackalloc char[unicodeScalar.Utf16CodeUnitCount];
            unicodeScalar.CopyUtf16CodeUnitsTo(span);
            return RawString.AsSpan().Slice(startIndex).IndexOf(span, StringComparison.Ordinal);
        }

        public int IndexOf(UnicodeScalar unicodeScalar, int startIndex, int count)
        {
            Span<char> span = stackalloc char[unicodeScalar.Utf16CodeUnitCount];
            unicodeScalar.CopyUtf16CodeUnitsTo(span);
            return RawString.AsSpan().Slice(startIndex, count).IndexOf(span, StringComparison.Ordinal);
        }

        public int IndexOf(string value)
        {
            return RawString.IndexOf(value);
        }

        public int IndexOf(string value, int startIndex)
        {
            return RawString.IndexOf(value, startIndex);
        }

        public int IndexOf(string value, int startIndex, int count)
        {
            return RawString.IndexOf(value, startIndex, count);
        }

        public int LastIndexOf(UnicodeScalar unicodeScalar)
        {
            Span<char> span = stackalloc char[unicodeScalar.Utf16CodeUnitCount];
            unicodeScalar.CopyUtf16CodeUnitsTo(span);
            return RawString.AsSpan().LastIndexOf(span);
        }

        public int LastIndexOf(UnicodeScalar unicodeScalar, int startIndex)
        {
            Span<char> span = stackalloc char[unicodeScalar.Utf16CodeUnitCount];
            unicodeScalar.CopyUtf16CodeUnitsTo(span);
            return RawString.AsSpan().Slice(startIndex).LastIndexOf(span);
        }

        public int LastIndexOf(UnicodeScalar unicodeScalar, int startIndex, int count)
        {
            Span<char> span = stackalloc char[unicodeScalar.Utf16CodeUnitCount];
            unicodeScalar.CopyUtf16CodeUnitsTo(span);
            return RawString.AsSpan().Slice(startIndex, count).LastIndexOf(span);
        }

        public int LastIndexOf(string value)
        {
            return RawString.LastIndexOf(value);
        }

        public int LastIndexOf(string value, int startIndex)
        {
            return RawString.LastIndexOf(value, startIndex);
        }

        public int LastIndexOf(string value, int startIndex, int count)
        {
            return RawString.LastIndexOf(value, startIndex, count);
        }
    }
}
