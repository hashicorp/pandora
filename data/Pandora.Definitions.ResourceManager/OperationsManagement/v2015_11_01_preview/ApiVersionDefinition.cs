using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.OperationsManagement.v2015_11_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2015-11-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ManagementAssociation.Definition(),
        new ManagementConfiguration.Definition(),
        new Solution.Definition(),
    };
}
