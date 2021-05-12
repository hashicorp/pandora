using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.DataPlane.AppConfiguration.v1_0
{
    public class Definition : ApiVersionDefinition
    {
        public string ApiVersion => "1.0";
        public bool Generate => true;
        public bool Preview => false;

        public IEnumerable<ApiDefinition> Apis => new List<ApiDefinition>
        {
        };
    }
}