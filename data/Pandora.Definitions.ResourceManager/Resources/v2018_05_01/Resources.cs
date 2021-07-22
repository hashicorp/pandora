using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Resources.v2018_05_01
{
    public class Resources : ApiVersionDefinition
    {
        public string ApiVersion => "2018-05-01";
        public bool Generate => true;
        public bool Preview => false;

        public IEnumerable<ApiDefinition> Apis => new List<ApiDefinition>
        {
            new ResourceGroup.Definition()
        };
    }
}