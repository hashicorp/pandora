using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ConfidentialLedger;

public partial class Service : ServiceDefinition
{
    public string Name => "ConfidentialLedger";
    public string? ResourceProvider => "Microsoft.ConfidentialLedger";
}
