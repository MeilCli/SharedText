using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SharedText.NETStandard
{
    public sealed partial class Utf16SharedString : ISharedString<Utf16SharedString, string>
    {
        public static readonly Utf16SharedString Empty = new Utf16SharedString(string.Empty);
        private const int maxStackallocSize = 128;

        public string RawString { get; }

        public int Length => RawString.Length;

        public IReadOnlyCollection<(int index, int length, SharedSpan sharedSpan)> Spans { get; }

        public Utf16SharedString(string value)
        {
            RawString = value;
            Spans = new List<(int, int, SharedSpan)>(0).AsReadOnly();
        }

        internal Utf16SharedString(string value, IReadOnlyCollection<(int, int, SharedSpan)> spans)
        {
            RawString = value;
            Spans = spans;
        }

        private IReadOnlyCollection<(int, int, SharedSpan)> sliceSpan(int startIndex, int length)
        {
            var newSpanList = new List<(int, int, SharedSpan)>(Spans.Count);
            foreach (var span in Spans)
            {
                if (span.index + span.length < startIndex)
                {
                    continue;
                }
                if (startIndex + length < span.index)
                {
                    continue;
                }

                int newStartIndex;
                if (span.index < startIndex)
                {
                    newStartIndex = 0;
                }
                else
                {
                    newStartIndex = span.index - startIndex;
                }

                int newLength;
                if (span.index + span.length < startIndex + length)
                {
                    newLength = span.length;
                }
                else
                {
                    newLength = (startIndex + length) - span.index;
                }

                newSpanList.Add((newStartIndex, newLength, span.sharedSpan));
            }

            return newSpanList.AsReadOnly();
        }

        private IReadOnlyCollection<(int, int, SharedSpan)> swipeSpan(int count)
        {
            var newSpanList = new List<(int, int, SharedSpan)>(Spans.Count);
            foreach (var span in Spans)
            {
                newSpanList.Add((span.index + count, span.length, span.sharedSpan));
            }

            return newSpanList;
        }

        public IEnumerator<UnicodeScalar> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Equals(Utf16SharedString other)
        {
            throw new NotImplementedException();
        }

        public Utf16SharedString Insert(int startIndex, string value)
        {
            throw new NotImplementedException();
        }

        public Utf16SharedString Remove(int startIndex)
        {
            throw new NotImplementedException();
        }

        public Utf16SharedString Remove(int startIndex, int count)
        {
            throw new NotImplementedException();
        }

        public Utf16SharedString Replace(UnicodeScalar oldValue, UnicodeScalar newValue)
        {
            throw new NotImplementedException();
        }

        public Utf16SharedString Replace(string oldValue, string newValue)
        {
            throw new NotImplementedException();
        }

        public Utf16SharedString[] Split(ReadOnlySpan<UnicodeScalar> separator)
        {
            throw new NotImplementedException();
        }

        public Utf16SharedString[] Split(ReadOnlySpan<UnicodeScalar> separator, int maxCount)
        {
            throw new NotImplementedException();
        }

        public Utf16SharedString[] Split(string separator)
        {
            throw new NotImplementedException();
        }

        public Utf16SharedString[] Split(string separator, int maxCount)
        {
            throw new NotImplementedException();
        }

        public Utf16SharedString Substring(int startIndex)
        {
            return new Utf16SharedString(this.RawString.Substring(startIndex), sliceSpan(startIndex, Length - startIndex));
        }

        public Utf16SharedString Substring(int startIndex, int length)
        {
            return new Utf16SharedString(this.RawString.Substring(startIndex, length), sliceSpan(startIndex, length));
        }

        public Utf16SharedString ToLowerInvariant()
        {
            return new Utf16SharedString(this.RawString.ToLowerInvariant(), Spans);
        }

        public Utf16SharedString ToUpperInvariant()
        {
            return new Utf16SharedString(this.RawString.ToUpperInvariant(), Spans);
        }
    }
}
