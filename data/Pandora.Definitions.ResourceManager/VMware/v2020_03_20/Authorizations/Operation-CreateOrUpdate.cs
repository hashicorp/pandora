using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.Authorizations
{
    internal class CreateOrUpdateOperation : Operations.PutOperation
    {
        public override bool LongRunning()
        {
            return true;
        }

        public override Type? RequestObject()
        {
            return typeof(ExpressRouteAuthorizationModel);
        }

        public override ResourceID? ResourceId()
        {
            return new AuthorizationId();
        }

        public override Type? ResponseObject()
        {
            return typeof(ExpressRouteAuthorizationModel);
        }


    }
}
