using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01
{
    public partial class Definition : ApiVersionDefinition
    {
        public string ApiVersion => "2021-02-01";
        public bool Preview => false;

        public IEnumerable<ApiDefinition> Apis => new List<ApiDefinition>
        {
            new Accounts.Definition(),
            new Creators.Definition(),
        };
    }
}
