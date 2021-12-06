using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2021_08_01.RedisEnterprise
{
    internal class DatabasesGetOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new DatabaseId();

        public override Type? ResponseObject() => typeof(DatabaseModel);


    }
}
