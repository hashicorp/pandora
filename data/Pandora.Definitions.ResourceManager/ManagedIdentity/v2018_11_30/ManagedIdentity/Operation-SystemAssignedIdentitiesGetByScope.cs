using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ManagedIdentity.v2018_11_30.ManagedIdentity
{
    internal class SystemAssignedIdentitiesGetByScope : GetOperation
    {
        public override object? ResponseObject()
        {
            return new SystemAssignedIdentity();
        }

        public override string? UriSuffix()
        {
            return "/{scope}/providers/Microsoft.ManagedIdentity/identities/default";
        }


    }
}
