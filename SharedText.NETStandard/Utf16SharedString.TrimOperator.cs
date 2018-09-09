using System;
using System.Collections.Generic;
using System.Text;

namespace SharedText.NETStandard
{
    public partial class Utf16SharedString
    {
        public Utf16SharedString Trim()
        {
            return trimResult(RawString.AsSpan().Trim());
        }

        public Utf16SharedString Trim(UnicodeScalar trimScalar)
        {
            return trimResult(RawString.AsSpan().TrimStart(trimScalar).TrimEnd(trimScalar));
        }

        public Utf16SharedString Trim(ReadOnlySpan<UnicodeScalar> trimScalars)
        {
            return trimResult(RawString.AsSpan().TrimStart(trimScalars).TrimEnd(trimScalars));
        }

        public Utf16SharedString TrimStart()
        {
            return trimResult(RawString.AsSpan().TrimStart());
        }

        public Utf16SharedString TrimStart(UnicodeScalar trimScalar)
        {
            return trimResult(RawString.AsSpan().TrimStart(trimScalar));
        }

        public Utf16SharedString TrimStart(ReadOnlySpan<UnicodeScalar> trimScalars)
        {
            return trimResult(RawString.AsSpan().TrimStart(trimScalars));
        }

        public Utf16SharedString TrimEnd()
        {
            return trimResult(RawString.AsSpan().TrimEnd());
        }

        public Utf16SharedString TrimEnd(UnicodeScalar trimScalar)
        {
            return trimResult(RawString.AsSpan().TrimEnd(trimScalar));
        }

        public Utf16SharedString TrimEnd(ReadOnlySpan<UnicodeScalar> trimScalars)
        {
            return trimResult(RawString.AsSpan().TrimEnd(trimScalars));
        }

        private Utf16SharedString trimResult(ReadOnlySpan<char> trimedSpan)
        {
            if (trimedSpan.IsEmpty)
            {
                return Empty;
            }
            int startIndex = RawString.IndexOf(trimedSpan[0]);
            return new Utf16SharedString(new string(trimedSpan.ToArray()), sliceSpan(startIndex, trimedSpan.Length));
        }
    }
}
