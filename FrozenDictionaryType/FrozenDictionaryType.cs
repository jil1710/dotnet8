using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrozenDictionaryType
{
    internal class FrozenDictionaryType
    {
        private static readonly FrozenDictionary<string, string> staticData =
            LoadStaticData().ToFrozenDictionary();

        // lly, FrozenSet<int> a = new List<int>(){1,1,2,2,3,4,5,5}.ToFrozenSet(); it's just create immutable set or readonly set like above

        private static Dictionary<string, string> LoadStaticData()
        {
            return new Dictionary<string, string>() { { "Key1", "Value1" }, { "Key2", "Value2" }, { "Key3", "Value3" } };

        }

        internal string GetValue(string key)
        {
            
            if (staticData.TryGetValue(key, out string? keyValue))
            {
                return keyValue;
            }

            return string.Empty;
        }

    }
}
