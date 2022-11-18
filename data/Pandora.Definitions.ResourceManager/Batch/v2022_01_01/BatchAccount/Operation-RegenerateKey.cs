using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2022_01_01.BatchAccount;

internal class RegenerateKeyOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(BatchAccountRegenerateKeyParametersModel);

\t\tpublic override ResourceID? ResourceId() => new BatchAccountId();

\t\tpublic override Type? ResponseObject() => typeof(BatchAccountKeysModel);

\t\tpublic override string? UriSuffix() => "/regenerateKeys";


}
