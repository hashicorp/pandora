using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2022_10_01.BatchAccount;

internal class RegenerateKeyOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(BatchAccountRegenerateKeyParametersModel);

    public override ResourceID? ResourceId() => new BatchAccountId();

    public override Type? ResponseObject() => typeof(BatchAccountKeysModel);

    public override string? UriSuffix() => "/regenerateKeys";


}
