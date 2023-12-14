// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.RoleManagement.StableV1.RoleManagementDirectoryResourceNamespaceResourceAction;

internal class UpdateRoleManagementDirectoryResourceNamespaceByIdResourceActionByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(UnifiedRbacResourceActionModel);
    public override ResourceID? ResourceId() => new RoleManagementDirectoryResourceNamespaceIdResourceActionId();
    public override Type? ResponseObject() => typeof(UnifiedRbacResourceActionModel);
    public override string? UriSuffix() => null;
}
