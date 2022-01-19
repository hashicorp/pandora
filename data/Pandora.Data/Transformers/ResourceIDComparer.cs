using System;
using System.Collections.Generic;
using Pandora.Data.Models;

namespace Pandora.Data.Transformers;

public class ResourceIDComparer : IEqualityComparer<ResourceIdDefinition>
{
    public bool Equals(ResourceIdDefinition a, ResourceIdDefinition b)
    {
        // we're intentionally not comparing the other sections here since this is unique-enough
        return a.Name == b.Name && a.IdString == b.IdString;
    }

    public int GetHashCode(ResourceIdDefinition obj)
    {
        return HashCode.Combine(obj.Name, obj.IdString);
    }
}