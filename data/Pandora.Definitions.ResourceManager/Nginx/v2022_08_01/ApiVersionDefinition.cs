using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Nginx.v2022_08_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-08-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new NginxCertificate.Definition(),
        new NginxConfiguration.Definition(),
        new NginxDeployment.Definition(),
    };
}
