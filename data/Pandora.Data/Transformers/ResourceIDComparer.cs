using System;
using System.Collections.Generic;
using Pandora.Data.Models;

namespace Pandora.Data.Transformers
{
    public class ResourceIDComparer : IEqualityComparer<ResourceIdDefinition>
    {
        public bool Equals(ResourceIdDefinition a, ResourceIdDefinition b)
        {
            return a.Name == b.Name && a.Format == b.Format;
        }

        public int GetHashCode(ResourceIdDefinition obj)
        {
            return HashCode.Combine(obj.Name, obj.Format);
        }
    }
}