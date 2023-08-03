// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.ServicePrincipals.Beta.ServicePrincipalAppRoleAssignedTo;

internal class AppRoleAssignedToId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/servicePrincipals/{servicePrincipalId}/appRoleAssignedTo/{appRoleAssignmentId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticServicePrincipals", "servicePrincipals"),
        ResourceIDSegment.UserSpecified("servicePrincipalId"),
        ResourceIDSegment.Static("staticAppRoleAssignedTo", "appRoleAssignedTo"),
        ResourceIDSegment.UserSpecified("appRoleAssignmentId")
    };
}
