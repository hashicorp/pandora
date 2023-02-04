using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Migrate.v2020_07_07;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-07-07";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new HyperVCluster.Definition(),
        new HyperVHost.Definition(),
        new HyperVJobs.Definition(),
        new HyperVMachines.Definition(),
        new HyperVRunAsAccounts.Definition(),
        new HyperVSites.Definition(),
        new Jobs.Definition(),
        new Machines.Definition(),
        new MasterSites.Definition(),
        new Migrates.Definition(),
        new PrivateEndpointConnection.Definition(),
        new PrivateLinkResources.Definition(),
        new RunAsAccounts.Definition(),
        new Sites.Definition(),
        new VCenter.Definition(),
    };
}
