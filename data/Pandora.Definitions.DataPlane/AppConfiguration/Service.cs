using System.Collections.Generic;
using Pandora.Definitions.DataPlane.Kudu.Unversioned;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.DataPlane.AppConfiguration
{
    public class Service : ServiceDefinition
    {
        public string Name => "AppConfiguration";
        public bool Generate => true;
        public string? ResourceProvider => null;
        public IEnumerable<TerraformResourceDefinition> Resources => new List<TerraformResourceDefinition>();
    }
}