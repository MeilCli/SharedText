using System;
using System.Collections.Generic;
using System.Text;

namespace SharedText.NETStandard
{
    public interface ISharedStringBuilder<TSystemString, TSystemChar>
    {
        ISharedStringBuilder<TSystemString, TSystemChar> Append(bool value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Append(sbyte value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Append(byte value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Append(short value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Append(ushort value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Append(int value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Append(uint value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Append(long value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Append(ulong value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Append(float value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Append(double value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Append(decimal value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Append(TSystemChar value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Append(ReadOnlySpan<TSystemChar> value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Append(TSystemString value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Append(object value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> AppendLine();

        ISharedStringBuilder<TSystemString, TSystemChar> AppendLine(TSystemString value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Clear();

        ISharedStringBuilder<TSystemString, TSystemChar> Insert(int index, bool value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Insert(int index, sbyte value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Insert(int index, byte value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Insert(int index, short value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Insert(int index, ushort value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Insert(int index, int value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Insert(int index, uint value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Insert(int index, long value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Insert(int index, ulong value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Insert(int index, float value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Insert(int index, double value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Insert(int index, decimal value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Insert(int index, TSystemChar value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Insert(int index, ReadOnlySpan<TSystemChar> value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Insert(int index, TSystemString value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Insert(int index, object value, SharedSpan span = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Remove(int index, int length);

        // maybe, unsafe
        ISharedStringBuilder<TSystemString, TSystemChar> Replace(TSystemChar oldChar, TSystemChar newChar, SharedSpan newSpan = null);

        ISharedStringBuilder<TSystemString, TSystemChar> Replace(TSystemString oldString, TSystemString newString, SharedSpan newSpan = null);
    }
}
