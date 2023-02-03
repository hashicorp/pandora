using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Migrate.v2020_01_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-01-01";
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
        new RunAsAccounts.Definition(),
        new Sites.Definition(),
        new VCenter.Definition(),
    };
}
