using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;

internal class CreateOperation : Operations.PutOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(StorageAccountCreateParametersModel);

    public override ResourceID? ResourceId() => new StorageAccountId();

    public override Type? ResponseObject() => typeof(StorageAccountModel);


}
