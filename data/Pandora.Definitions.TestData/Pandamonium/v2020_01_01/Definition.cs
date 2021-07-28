using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Pandamonium.v2020_01_01
{
    public class Definition : ApiVersionDefinition
    {
        public string ApiVersion => "2020-01-01";
        public bool Generate => true;
        public bool Preview => false;

        public IEnumerable<ApiDefinition> Apis => new List<ApiDefinition>
        {
            new Grouping.Definition()
        };
    }
}