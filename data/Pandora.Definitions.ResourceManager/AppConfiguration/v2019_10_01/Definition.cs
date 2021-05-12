using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2019_10_01
{
    public class Definition : ApiVersionDefinition
    {
        public string ApiVersion => "2019-10-01";
        public bool Generate => true;
        public bool Preview => false;
        
        public IEnumerable<ApiDefinition> Apis => new List<ApiDefinition>
        {
            new Store.Definition()
        };
    }
}