using System;
using System.Collections.Generic;
using System.Text;

namespace SharedText.NETStandard
{
    public interface ISharedString<TSharedString, TSystemString>
        : IEnumerable<UnicodeScalar>, IEquatable<TSharedString>
    {
        TSystemString RawString { get; }

        int Length { get; }

        IReadOnlyCollection<(int index, int length, SharedSpan sharedSpan)> Spans { get; }

        bool Contains(UnicodeScalar unicodeScalar);

        bool Contains(TSystemString value);

        bool StartsWith(UnicodeScalar unicodeScalar);

        bool StartsWith(TSystemString value);

        bool EndsWith(UnicodeScalar unicodeScalar);

        bool EndsWith(TSystemString value);

        int IndexOf(UnicodeScalar unicodeScalar);

        int IndexOf(UnicodeScalar unicodeScalar, int startIndex);

        int IndexOf(UnicodeScalar unicodeScalar, int startIndex, int count);

        int IndexOf(TSystemString value);

        int IndexOf(TSystemString value, int startIndex);

        int IndexOf(TSystemString value, int startIndex, int count);

        int LastIndexOf(UnicodeScalar unicodeScalar);

        int LastIndexOf(UnicodeScalar unicodeScalar, int startIndex);

        int LastIndexOf(UnicodeScalar unicodeScalar, int startIndex, int count);

        int LastIndexOf(TSystemString value);

        int LastIndexOf(TSystemString value, int startIndex);

        int LastIndexOf(TSystemString value, int startIndex, int count);

        TSharedString Insert(int startIndex, TSystemString value);

        TSharedString PadLeft(int totalWidth);

        TSharedString PadLeft(int totalWidth, UnicodeScalar paddingScalar);

        TSharedString PadRight(int totalWidth);

        TSharedString PadRight(int totalWidth, UnicodeScalar paddingScalar);

        TSharedString Remove(int startIndex);

        TSharedString Remove(int startIndex, int count);

        /// <summary>
        /// Replace string using <see cref="UnicodeScalar"/>.
        /// If in range of span, replace to empty span.
        /// </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        TSharedString Replace(UnicodeScalar oldValue, UnicodeScalar newValue);

        /// <summary>
        /// Replace string using <see cref="TSystemString"/>.
        /// If in range of span, replace to empty span.
        /// </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        TSharedString Replace(TSystemString oldValue, TSystemString newValue);

        TSharedString[] Split(ReadOnlySpan<UnicodeScalar> separator);

        TSharedString[] Split(ReadOnlySpan<UnicodeScalar> separator, int maxCount);

        TSharedString[] Split(TSystemString separator);

        TSharedString[] Split(TSystemString separator, int maxCount);

        TSharedString Substring(int startIndex);

        TSharedString Substring(int startIndex, int length);

        TSharedString ToLowerInvariant();

        TSharedString ToUpperInvariant();

        TSharedString Trim();

        TSharedString Trim(UnicodeScalar trimScalar);

        TSharedString Trim(ReadOnlySpan<UnicodeScalar> trimScalars);

        TSharedString TrimStart();

        TSharedString TrimStart(UnicodeScalar trimScalar);

        TSharedString TrimStart(ReadOnlySpan<UnicodeScalar> trimScalars);

        TSharedString TrimEnd();

        TSharedString TrimEnd(UnicodeScalar trimScalar);

        TSharedString TrimEnd(ReadOnlySpan<UnicodeScalar> trimScalars);
    }
}
