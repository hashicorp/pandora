using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.DataLakeStore.v2016_11_01.Accounts
{
    internal class CreateOperation : Operations.PutOperation
    {
        public override bool LongRunning() => true;

        public override Type? RequestObject() => typeof(CreateDataLakeStoreAccountParametersModel);

        public override ResourceID? ResourceId() => new AccountId();

        public override Type? ResponseObject() => typeof(DataLakeStoreAccountModel);


    }
}
