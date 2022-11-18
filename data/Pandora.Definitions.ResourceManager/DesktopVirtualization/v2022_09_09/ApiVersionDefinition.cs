using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-09-09";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Application.Definition(),
        new ApplicationGroup.Definition(),
        new Desktop.Definition(),
        new HostPool.Definition(),
        new MSIXPackage.Definition(),
        new MsixImage.Definition(),
        new ScalingPlan.Definition(),
        new ScalingPlanPooledSchedule.Definition(),
        new SessionHost.Definition(),
        new StartMenuItem.Definition(),
        new UserSession.Definition(),
        new Workspace.Definition(),
    };
}
