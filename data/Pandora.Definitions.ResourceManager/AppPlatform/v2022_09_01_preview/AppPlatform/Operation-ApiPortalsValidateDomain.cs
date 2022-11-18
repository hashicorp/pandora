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

internal class ApiPortalsValidateDomainOperation : Operations.PostOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(CustomDomainValidatePayloadModel);

\t\tpublic override ResourceID? ResourceId() => new ApiPortalId();

\t\tpublic override Type? ResponseObject() => typeof(CustomDomainValidateResultModel);

\t\tpublic override string? UriSuffix() => "/validateDomain";


}
