using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Accounts
{
    internal class CreateOrUpdateOperation : Operations.PutOperation
    {
        public override Type? RequestObject()
        {
            return typeof(MapsAccountModel);
        }

        public override ResourceID? ResourceId()
        {
            return new AccountId();
        }

        public override Type? ResponseObject()
        {
            return typeof(MapsAccountModel);
        }


    }
}
