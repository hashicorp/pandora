using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_02_10_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-02-10-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Application.Definition(),
        new ApplicationGroup.Definition(),
        new Desktop.Definition(),
        new HostPool.Definition(),
        new MSIXPackage.Definition(),
        new MsixImage.Definition(),
        new PrivateLink.Definition(),
        new ScalingPlan.Definition(),
        new SessionHost.Definition(),
        new StartMenuItem.Definition(),
        new UserSession.Definition(),
        new Workspace.Definition(),
    };
}
