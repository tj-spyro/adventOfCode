// ReSharper disable CheckNamespace

using System;
using System.Collections.Generic;
using System.Linq;

namespace DockingData
{
    public class BitMasker : IBitMasker
    {
        public ulong Apply(string bitMask, long inputValue)
        {
            var value = GetBitString(inputValue);
            var result = Convert.ToUInt64(new string(value.Select((c, i) => bitMask[i] == 'X' ? c : bitMask[i]).ToArray()), 2);

            return result;
        }

        public IEnumerable<long> ApplyMultiple(string bitMask, long inputValue)
        {
            var address = GetBitString(inputValue);

            var result = new string(address.Select((c, i) => bitMask[i] == '0' ? c : bitMask[i]).ToArray());

            var addresses = GetAddresses(result);

            return addresses.Select(a => Convert.ToInt64(a, 2));
        }

        private static string GetBitString(long input) => Convert.ToString(input, 2).PadLeft(36, '0');

        private static IEnumerable<string> GetAddresses(string address)
        {
            var index = address.IndexOf('X');

            if (index == -1)
            {
                return new []{ address };
            }

            var replacements = new List<string>
            {
                address.Remove(index, 1).Insert(index, "0"),
                address.Remove(index, 1).Insert(index, "1")
            };

            return replacements.SelectMany(GetAddresses);
        }
    }
}