using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2016-11-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Accounts.Definition(),
        new ComputePolicies.Definition(),
        new DataLakeStoreAccounts.Definition(),
        new FirewallRules.Definition(),
        new Locations.Definition(),
        new StorageAccounts.Definition(),
    };
}
