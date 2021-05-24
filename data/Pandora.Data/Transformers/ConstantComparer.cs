using System.Collections.Generic;
using System.Linq;
using Pandora.Data.Models;

namespace Pandora.Data.Transformers
{
    internal class ConstantComparer : IEqualityComparer<ConstantDefinition>
    {
        public bool Equals(ConstantDefinition a, ConstantDefinition b)
        {
            if (a.Name != b.Name)
            {
                return false;
            }

            if (a.CaseInsensitive != b.CaseInsensitive)
            {
                return false;
            }

            if (a.Type != b.Type)
            {
                return false;
            }

            if (a.Values.Count != b.Values.Count)
            {
                return false;
            }

            return a.Values.All(value => b.Values.Contains(value));
        }

        public int GetHashCode(ConstantDefinition obj)
        {
            var sortedValues = obj.Values.OrderBy(v => v.Key);

            var sortedValsString = string.Join("", sortedValues);
            return obj.Name.GetHashCode() ^ obj.CaseInsensitive.GetHashCode() ^ sortedValsString.GetHashCode();
        }
    }
}