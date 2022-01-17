using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHsc
{
    public partial class Service : ServiceDefinition
    {
        public string Name => "PostgreSqlHsc";
        public string? ResourceProvider => "Microsoft.DBforPostgreSQL";
    }
}
