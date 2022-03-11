using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Web;

public partial class Service : ServiceDefinition
{
    public string Name => "Web";
    public string? ResourceProvider => "Microsoft.CertificateRegistration";
}
