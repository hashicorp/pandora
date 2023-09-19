// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementDirectoryResourceNamespaceResourceActionAuthenticationContext;

internal class GetRoleManagementDirectoryResourceNamespaceByIdResourceActionByIdAuthenticationContextOperation : Operations.GetOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override ResourceID? ResourceId() => new RoleManagementDirectoryResourceNamespaceIdResourceActionId();
    public override Type? ResponseObject() => typeof(AuthenticationContextClassReferenceModel);
    public override string? UriSuffix() => "/authenticationContext";
}
