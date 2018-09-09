using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SharedText.NETStandard
{
    public sealed class SharedSpan : IEquatable<SharedSpan>
    {
        public TextSize TextSize { get; }

        public TextStyle TextStyle { get; }

        public Color TextColor { get; }

        public Color BackgroundColor { get; }

        public bool IsClickable { get; }

        public object ClickValue { get; }

        public SharedSpan(
            TextSize? textSize = null,
            TextStyle textStyle = TextStyle.None,
            Color? textColor = null,
            Color? backgroundColor = null,
            bool isClickable = false,
            object clickValue = null)
        {
            TextSize = textSize ?? TextSize.Normal;
            TextStyle = textStyle;
            TextColor = textColor ?? Color.Empty;
            BackgroundColor = backgroundColor ?? Color.Empty;
            IsClickable = isClickable;
            ClickValue = clickValue;
        }

        public bool Equals(SharedSpan other)
        {
            if (other == null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return TextSize.Equals(other.TextSize)
                   && TextStyle.Equals(other.TextStyle)
                   && TextColor.Equals(other.TextColor)
                   && BackgroundColor.Equals(other.BackgroundColor)
                   && IsClickable == other.IsClickable
                   && Equals(ClickValue, other.ClickValue);
        }

        public override bool Equals(object obj)
        {
            if (obj is SharedSpan sharedSpan)
            {
                return Equals(sharedSpan);
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = TextSize.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)TextStyle;
                hashCode = (hashCode * 397) ^ TextColor.GetHashCode();
                hashCode = (hashCode * 397) ^ BackgroundColor.GetHashCode();
                hashCode = (hashCode * 397) ^ IsClickable.GetHashCode();
                hashCode = (hashCode * 397) ^ (ClickValue != null ? ClickValue.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
