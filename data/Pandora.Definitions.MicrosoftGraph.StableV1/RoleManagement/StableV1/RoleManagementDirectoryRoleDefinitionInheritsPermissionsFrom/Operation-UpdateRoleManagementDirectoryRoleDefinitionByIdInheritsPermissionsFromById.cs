// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.RoleManagement.StableV1.RoleManagementDirectoryRoleDefinitionInheritsPermissionsFrom;

internal class UpdateRoleManagementDirectoryRoleDefinitionByIdInheritsPermissionsFromByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(UnifiedRoleDefinitionModel);
    public override ResourceID? ResourceId() => new RoleManagementDirectoryRoleDefinitionIdInheritsPermissionsFromId();
    public override Type? ResponseObject() => typeof(UnifiedRoleDefinitionModel);
    public override string? UriSuffix() => null;
}
