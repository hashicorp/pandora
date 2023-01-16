using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2018-09-15";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ArmTemplates.Definition(),
        new ArtifactSources.Definition(),
        new Artifacts.Definition(),
        new Costs.Definition(),
        new CustomImages.Definition(),
        new Disks.Definition(),
        new Environments.Definition(),
        new Formulas.Definition(),
        new GalleryImages.Definition(),
        new GlobalSchedules.Definition(),
        new Labs.Definition(),
        new NotificationChannels.Definition(),
        new Policies.Definition(),
        new PolicySets.Definition(),
        new Schedules.Definition(),
        new Secrets.Definition(),
        new ServiceFabricSchedules.Definition(),
        new ServiceFabrics.Definition(),
        new ServiceRunners.Definition(),
        new Users.Definition(),
        new VirtualMachineSchedules.Definition(),
        new VirtualMachines.Definition(),
        new VirtualNetworks.Definition(),
    };
}
