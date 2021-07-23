using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01
{
    public partial class Definition : ApiVersionDefinition
    {
        public string ApiVersion => "2018-08-01";
        public bool Preview => false;

        public IEnumerable<ApiDefinition> Apis => new List<ApiDefinition>
        {
            new Endpoints.Definition(),
            new HeatMaps.Definition(),
            new Profiles.Definition(),
        };
    }
}
