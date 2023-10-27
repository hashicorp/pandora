using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Communication.v2023_04_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-04-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new CommunicationServices.Definition(),
        new Domains.Definition(),
        new EmailServices.Definition(),
        new SenderUsernames.Definition(),
    };
}
