using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-03-20";
    public bool Preview => false;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Authorizations.Definition(),
        new Clusters.Definition(),
        new HcxEnterpriseSites.Definition(),
        new Locations.Definition(),
        new PrivateClouds.Definition(),
    };
}
