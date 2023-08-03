using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.MicrosoftGraph.Beta.ServicePrincipals.Beta.ServicePrincipalAppRoleAssignedTo;

internal class CreateAppRoleAssignedToOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(AppRoleAssignmentModel);
    public override ResourceID? ResourceId() => new ServicePrincipalId();
    public override Type? ResponseObject() => typeof(AppRoleAssignmentModel);
    public override string? UriSuffix() => "/appRoleAssignedTo";
}
