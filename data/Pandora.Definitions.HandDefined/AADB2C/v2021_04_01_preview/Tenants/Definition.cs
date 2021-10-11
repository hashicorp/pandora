using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.HandDefined.AADB2C.v2021_04_01_preview.Tenants
{
    internal class Definition : ApiDefinition
    {
        // https://docs.microsoft.com/en-us/rest/api/activedirectory/b2c-tenants
        public string ApiVersion => "2021-04-01-preview";
        public string Name => "Tenants";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CheckNameAvailabilityOperation(),
            new Create(),
            new Delete(),
            new Get(),
            new ListByResourceGroup(),
            new ListBySubscription(),
            new Update(),
        };
    }
}