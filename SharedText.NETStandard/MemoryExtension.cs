using System;
using System.Collections.Generic;
using System.Text;

namespace SharedText.NETStandard
{
    internal static class MemoryExtension
    {
        public static ReadOnlySpan<char> TrimStart(this ReadOnlySpan<char> span, UnicodeScalar unicodeScalar)
        {
            Span<char> trimSpan = stackalloc char[unicodeScalar.Utf16CodeUnitCount];
            unicodeScalar.CopyUtf16CodeUnitsTo(trimSpan);

            int start = 0;
            for (ref int i = ref start; i < span.Length;)
            {
                if (span.Slice(i).StartsWith(trimSpan, StringComparison.Ordinal) == false)
                {
                    break;
                }

                i += trimSpan.Length;
            }

            return span.Slice(start);
        }

        public static ReadOnlySpan<char> TrimStart(this ReadOnlySpan<char> span, ReadOnlySpan<UnicodeScalar> unicodeScalars)
        {
            char[][] trimCodePoints = new char[unicodeScalars.Length][];
            for (int i = 0; i < unicodeScalars.Length; i++)
            {
                UnicodeScalar unicodeScalar = unicodeScalars[i];
                char[] trimCodePoint = new char[unicodeScalar.Utf16CodeUnitCount];
                unicodeScalar.CopyUtf16CodeUnitsTo(trimCodePoint);
            }

            int start = 0;
            for (ref int i = ref start; i < span.Length;)
            {
                for (int j = 0; j < trimCodePoints.Length; j++)
                {
                    char[] trimCodePoint = trimCodePoints[j];
                    if (span.Slice(i).StartsWith(trimCodePoint, StringComparison.Ordinal))
                    {
                        i += trimCodePoint.Length;
                        goto Next;
                    }
                }

                break;
                Next:;
            }

            return span.Slice(start);
        }

        public static ReadOnlySpan<char> TrimEnd(this ReadOnlySpan<char> span, UnicodeScalar unicodeScalar)
        {
            Span<char> trimSpan = stackalloc char[unicodeScalar.Utf16CodeUnitCount];
            unicodeScalar.CopyUtf16CodeUnitsTo(trimSpan);

            int end = span.Length - 1;
            for (ref int i = ref end; 0 <= end;)
            {
                if (span.Slice(0, i + 1).EndsWith(trimSpan, StringComparison.Ordinal) == false)
                {
                    break;
                }

                i -= trimSpan.Length;
            }

            return span.Slice(0, end + 1);
        }

        public static ReadOnlySpan<char> TrimEnd(this ReadOnlySpan<char> span, ReadOnlySpan<UnicodeScalar> unicodeScalars)
        {
            char[][] trimCodePoints = new char[unicodeScalars.Length][];
            for (int i = 0; i < unicodeScalars.Length; i++)
            {
                UnicodeScalar unicodeScalar = unicodeScalars[i];
                char[] trimCodePoint = new char[unicodeScalar.Utf16CodeUnitCount];
                unicodeScalar.CopyUtf16CodeUnitsTo(trimCodePoint);
            }

            int end = span.Length - 1;
            for (ref int i = ref end; 0 <= end;)
            {
                for (int j = 0; j < trimCodePoints.Length; j++)
                {
                    char[] trimCodePoint = trimCodePoints[j];
                    if (span.Slice(0, i + 1).EndsWith(trimCodePoint, StringComparison.Ordinal))
                    {
                        i -= trimCodePoint.Length;
                        goto Next;
                    }
                }

                break;
                Next:;
            }

            return span.Slice(0, end + 1);
        }
    }
}
