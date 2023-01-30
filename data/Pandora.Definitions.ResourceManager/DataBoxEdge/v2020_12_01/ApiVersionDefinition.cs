using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-12-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Addons.Definition(),
        new Alerts.Definition(),
        new AvailableSkus.Definition(),
        new BandwidthSchedules.Definition(),
        new Containers.Definition(),
        new Devices.Definition(),
        new Jobs.Definition(),
        new MonitoringConfig.Definition(),
        new Nodes.Definition(),
        new Orders.Definition(),
        new Roles.Definition(),
        new Shares.Definition(),
        new StorageAccountCredentials.Definition(),
        new StorageAccounts.Definition(),
        new Triggers.Definition(),
        new Users.Definition(),
    };
}
