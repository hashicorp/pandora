using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ManagedIdentity.v2018_11_30.ManagedIdentity;

internal class ScopeId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{scope}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
                new()
                {
                    Name = "scope",
                    Type = ResourceIDSegmentType.Scope
                },

    };
}
