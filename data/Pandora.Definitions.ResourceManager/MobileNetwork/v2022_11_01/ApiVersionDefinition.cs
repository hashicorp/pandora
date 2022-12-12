using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-11-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AttachedDataNetwork.Definition(),
        new AttachedDataNetworks.Definition(),
        new DataNetwork.Definition(),
        new DataNetworks.Definition(),
        new MobileNetwork.Definition(),
        new MobileNetworks.Definition(),
        new PacketCoreControlPlane.Definition(),
        new PacketCoreControlPlaneCollectDiagnosticsPackage.Definition(),
        new PacketCoreControlPlaneReinstall.Definition(),
        new PacketCoreControlPlaneRollback.Definition(),
        new PacketCoreControlPlaneVersion.Definition(),
        new PacketCoreControlPlanes.Definition(),
        new PacketCoreDataPlane.Definition(),
        new PacketCoreDataPlanes.Definition(),
        new SIM.Definition(),
        new SIMGroup.Definition(),
        new SIMGroups.Definition(),
        new SIMPolicies.Definition(),
        new SIMPolicy.Definition(),
        new SIMs.Definition(),
        new Service.Definition(),
        new Services.Definition(),
        new Site.Definition(),
        new Sites.Definition(),
        new Slice.Definition(),
        new Slices.Definition(),
    };
}
