using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;

internal class ListKeysOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new StorageAccountId();

    public override Type? ResponseObject() => typeof(StorageAccountListKeysResultModel);

    public override Type? OptionsObject() => typeof(ListKeysOperation.ListKeysOptions);

    public override string? UriSuffix() => "/listKeys";

    internal class ListKeysOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public ListKeyExpandConstant Expand { get; set; }
    }
}
