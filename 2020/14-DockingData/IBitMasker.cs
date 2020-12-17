using System.Collections.Generic;

namespace DockingData
{
    public interface IBitMasker
    {
        ulong Apply(string bitMask, long inputValue);
        IEnumerable<long> ApplyMultiple(string bitMask, long inputValue);
    }
}