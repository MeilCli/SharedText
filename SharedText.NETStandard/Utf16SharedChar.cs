using System;
using System.Collections.Generic;
using System.Text;

namespace SharedText.NETStandard
{
    internal readonly struct Utf16SharedChar
    {
        internal readonly char Buffer;
        internal readonly SharedSpan SharedSpan;

        public Utf16SharedChar(char buffer, SharedSpan sharedSpan)
        {
            Buffer = buffer;
            SharedSpan = sharedSpan;
        }
    }
}
