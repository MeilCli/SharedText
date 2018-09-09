using System;

namespace SharedText.NETStandard
{
    [Flags]
    public enum TextStyle
    {
        None = 1,
        Bold = 1 << 1,
        Italic = 1 << 2
    }
}