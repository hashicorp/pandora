// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryAdministrativeUnitScopedRoleMember;

internal class CreateDirectoryAdministrativeUnitByIdScopedRoleMemberOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(ScopedRoleMembershipModel);
    public override ResourceID? ResourceId() => new DirectoryAdministrativeUnitId();
    public override Type? ResponseObject() => typeof(ScopedRoleMembershipModel);
    public override string? UriSuffix() => "/scopedRoleMembers";
}
