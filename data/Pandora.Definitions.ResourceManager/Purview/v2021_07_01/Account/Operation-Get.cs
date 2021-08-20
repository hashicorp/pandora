using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.Account
{
    internal class GetOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new AccountId();

        public override Type? ResponseObject() => typeof(AccountModel);


    }
}
