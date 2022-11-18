using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MixedReality.v2021_01_01.Key;

internal class RemoteRenderingAccountsRegenerateKeysOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(AccountKeyRegenerateRequestModel);

\t\tpublic override ResourceID? ResourceId() => new RemoteRenderingAccountId();

\t\tpublic override Type? ResponseObject() => typeof(AccountKeysModel);

\t\tpublic override string? UriSuffix() => "/regenerateKeys";


}
