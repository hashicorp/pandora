using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_09_01_preview.AppPlatform;

internal class ServicesRegenerateTestKeyOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(RegenerateTestKeyRequestPayloadModel);

\t\tpublic override ResourceID? ResourceId() => new SpringId();

\t\tpublic override Type? ResponseObject() => typeof(TestKeysModel);

\t\tpublic override string? UriSuffix() => "/regenerateTestKey";


}
