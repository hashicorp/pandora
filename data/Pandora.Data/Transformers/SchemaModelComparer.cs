using System;
using System.Collections.Generic;
using Pandora.Data.Models;

namespace Pandora.Data.Transformers
{
    public class SchemaModelComparer : IEqualityComparer<TerraformModelDefinition>
    {
        public bool Equals(TerraformModelDefinition x, TerraformModelDefinition y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Name == y.Name && Equals(x.Fields, y.Fields);
        }

        public int GetHashCode(TerraformModelDefinition obj)
        {
            return HashCode.Combine(obj.Name, obj.Fields);
        }
    }
}