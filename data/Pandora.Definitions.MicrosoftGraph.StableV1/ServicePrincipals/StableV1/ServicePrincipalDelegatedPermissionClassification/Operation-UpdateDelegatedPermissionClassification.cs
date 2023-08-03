using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.MicrosoftGraph.StableV1.ServicePrincipals.StableV1.ServicePrincipalDelegatedPermissionClassification;

internal class UpdateDelegatedPermissionClassificationOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(DelegatedPermissionClassificationModel);
    public override ResourceID? ResourceId() => new DelegatedPermissionClassificationId();
    public override Type? ResponseObject() => typeof(DelegatedPermissionClassificationModel);
    public override string? UriSuffix() => null;
}
