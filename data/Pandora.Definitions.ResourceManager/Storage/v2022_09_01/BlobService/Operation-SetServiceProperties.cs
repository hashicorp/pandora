using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_09_01.BlobService;

internal class SetServicePropertiesOperation : Operations.PutOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(BlobServicePropertiesModel);

\t\tpublic override ResourceID? ResourceId() => new StorageAccountId();

\t\tpublic override Type? ResponseObject() => typeof(BlobServicePropertiesModel);

\t\tpublic override string? UriSuffix() => "/blobServices/default";


}
