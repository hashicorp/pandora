using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.StorageAccounts;

internal class ListKeysOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

\t\tpublic override Type? RequestObject() => null;

\t\tpublic override ResourceID? ResourceId() => new StorageAccountId();

\t\tpublic override Type? ResponseObject() => typeof(StorageAccountListKeysResultModel);

\t\tpublic override Type? OptionsObject() => typeof(ListKeysOperation.ListKeysOptions);

\t\tpublic override string? UriSuffix() => "/listKeys";

    internal class ListKeysOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public ListKeyExpandConstant Expand { get; set; }
    }
}
