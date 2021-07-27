using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.Authorizations
{
    internal class CreateOrUpdate : PutOperation
    {
        public override bool LongRunning()
        {
            return true;
        }

        public override object? RequestObject()
        {
            return new ExpressRouteAuthorization();
        }

        public override ResourceID? ResourceId()
        {
            return new AuthorizationId();
        }

        public override object? ResponseObject()
        {
            return new ExpressRouteAuthorization();
        }


    }
}
