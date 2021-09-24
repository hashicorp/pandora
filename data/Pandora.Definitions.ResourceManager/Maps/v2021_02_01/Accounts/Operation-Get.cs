using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Accounts
{
    internal class GetOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new AccountId();

        public override Type? ResponseObject() => typeof(MapsAccountModel);


    }
}
