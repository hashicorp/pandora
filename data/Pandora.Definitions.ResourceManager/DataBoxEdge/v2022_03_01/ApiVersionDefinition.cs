using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-03-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Addons.Definition(),
        new Alerts.Definition(),
        new AvailableSkus.Definition(),
        new BandwidthSchedules.Definition(),
        new Containers.Definition(),
        new DeviceCapacityCheck.Definition(),
        new DeviceCapacityInfo.Definition(),
        new Devices.Definition(),
        new DiagnosticSettings.Definition(),
        new Jobs.Definition(),
        new MonitoringConfig.Definition(),
        new Nodes.Definition(),
        new Orders.Definition(),
        new Roles.Definition(),
        new Shares.Definition(),
        new StorageAccountCredentials.Definition(),
        new StorageAccounts.Definition(),
        new SupportPackages.Definition(),
        new Triggers.Definition(),
        new Users.Definition(),
    };
}
