using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ManagedIdentity.v2018_11_30.ManagedIdentity
{
    internal class UserAssignedIdentitiesCreateOrUpdateOperation : Operations.PutOperation
    {
        public override object? RequestObject()
        {
            return new IdentityModel();
        }

        public override ResourceID? ResourceId()
        {
            return new UserAssignedIdentitiesId();
        }

        public override object? ResponseObject()
        {
            return new IdentityModel();
        }


    }
}
