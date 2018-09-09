using System;
using System.Collections.Generic;
using System.Text;

namespace SharedText.NETStandard
{
    public struct TextSize : IEquatable<TextSize>
    {
        public static readonly TextSize UltraBig = new TextSize(1.5f);
        public static readonly TextSize Big = new TextSize(1.25f);
        public static readonly TextSize Normal = new TextSize(1f);
        public static readonly TextSize Small = new TextSize(0.75f);
        public static readonly TextSize UltraSmall = new TextSize(0.5f);

        public float Proportion { get; }

        public TextSize(float proportion)
        {
            Proportion = proportion;
        }

        public override bool Equals(object obj)
        {
            if (obj is TextSize fontSize)
            {
                return Equals(fontSize);
            }
            return false;
        }

        public bool Equals(TextSize textSize)
        {
            return Proportion == textSize.Proportion;
        }

        public override int GetHashCode()
        {
            return Proportion.GetHashCode();
        }

        public static bool operator ==(TextSize a, TextSize b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(TextSize a, TextSize b)
        {
            return a.Equals(b) == false;
        }
    }
}
