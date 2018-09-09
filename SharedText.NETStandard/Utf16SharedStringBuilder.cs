using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SharedText.NETStandard
{
    public sealed class Utf16SharedStringBuilder
    {
        private const int defaultCapacity = 16;

        private Utf16SharedChar[] values;

        public int Capacity { get; private set; }
        public int Length { get; private set; }

        public Utf16SharedStringBuilder() : this(defaultCapacity) { }

        public Utf16SharedStringBuilder(int capacity)
        {
            if (capacity < defaultCapacity)
            {
                capacity = defaultCapacity;
            }
            Capacity = capacity;
            this.values = new Utf16SharedChar[capacity];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void expandCapacity(int currentCapacity, int minimumCapacity)
        {
            int newCapacity = Math.Max(minimumCapacity, Math.Min(currentCapacity * 2, int.MaxValue));
            var newArray = new Utf16SharedChar[newCapacity];

            values.AsSpan().CopyTo(newArray);
            Capacity = newCapacity;
            values = newArray;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EnsureCapacity(int minimumCapacity)
        {
            int currentCapacity = Capacity;
            if (currentCapacity < minimumCapacity)
            {
                expandCapacity(currentCapacity, minimumCapacity);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void copyToSpanScalars(Span<Utf16SharedChar> span, ReadOnlySpan<char> values, SharedSpan valueSpan)
        {
            for (int i = 0; i < values.Length; i++)
            {
                span[i] = new Utf16SharedChar(values[i], valueSpan);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16SharedStringBuilder Append(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            ReadOnlySpan<char> valueSpan = value.AsSpan();

            EnsureCapacity(Length + valueSpan.Length);

            copyToSpanScalars(values.AsSpan().Slice(Length), valueSpan, null);
            Length += valueSpan.Length;

            return this;
        }
    }
}
