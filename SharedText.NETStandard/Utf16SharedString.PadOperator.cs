using System;
using System.Collections.Generic;
using System.Text;

namespace SharedText.NETStandard
{
    public partial class Utf16SharedString
    {
        public Utf16SharedString PadLeft(int totalWidth)
        {
            if (totalWidth <= Length)
            {
                return this;
            }

            return new Utf16SharedString(RawString.PadLeft(totalWidth), swipeSpan(totalWidth - Length));
        }

        public Utf16SharedString PadLeft(int totalWidth, UnicodeScalar paddingScalar)
        {
            if (totalWidth <= Length)
            {
                return this;
            }

            int paddingScalarWidth = paddingScalar.Utf16CodeUnitCount;
            int insertScalarCount = (totalWidth - Length) / paddingScalarWidth;
            int paddingLength = insertScalarCount * paddingScalarWidth;
            int paddedLength = Length + paddingLength;

            Span<char> paddingSpan = stackalloc char[paddingScalarWidth];
            paddingScalar.CopyUtf16CodeUnitsTo(paddingSpan);

            Span<char> span = paddedLength <= maxStackallocSize ? stackalloc char[paddedLength] : new char[paddedLength];
            RawString.AsSpan().CopyTo(span.Slice(paddingLength));
            for (int i = 0; i < paddingLength; i += paddingScalarWidth)
            {
                for (int j = 0; j < paddingScalarWidth; j++)
                {
                    span[i + j] = paddingSpan[j];
                }
            }

            return new Utf16SharedString(new string(span.ToArray()), swipeSpan(paddingLength));
        }

        public Utf16SharedString PadRight(int totalWidth)
        {
            if (totalWidth <= Length)
            {
                return this;
            }

            return new Utf16SharedString(RawString.PadRight(totalWidth), Spans);
        }

        public Utf16SharedString PadRight(int totalWidth, UnicodeScalar paddingScalar)
        {
            if (totalWidth <= Length)
            {
                return this;
            }

            int paddingScalarWidth = paddingScalar.Utf16CodeUnitCount;
            int insertScalarCount = (totalWidth - Length) / paddingScalarWidth;
            int paddedLength = Length + insertScalarCount * paddingScalarWidth;

            Span<char> paddingSpan = stackalloc char[paddingScalarWidth];
            paddingScalar.CopyUtf16CodeUnitsTo(paddingSpan);

            Span<char> span = paddedLength <= maxStackallocSize ? stackalloc char[paddedLength] : new char[paddedLength];
            RawString.AsSpan().CopyTo(span);
            for (int i = Length; i < paddedLength; i += paddingScalarWidth)
            {
                for (int j = 0; j < paddingScalarWidth; j++)
                {
                    span[i + j] = paddingSpan[j];
                }
            }

            return new Utf16SharedString(new string(span.ToArray()), Spans);
        }
    }
}
