using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ManagedServices.v2019_06_01;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2019-06-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new RegistrationAssignments.Definition(),
        new RegistrationDefinitions.Definition(),
    };
}
