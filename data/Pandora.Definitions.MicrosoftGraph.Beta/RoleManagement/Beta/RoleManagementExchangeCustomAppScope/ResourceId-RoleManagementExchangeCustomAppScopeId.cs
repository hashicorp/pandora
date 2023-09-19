// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementExchangeCustomAppScope;

internal class RoleManagementExchangeCustomAppScopeId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/roleManagement/exchange/customAppScopes/{customAppScopeId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticRoleManagement", "roleManagement"),
        ResourceIDSegment.Static("staticExchange", "exchange"),
        ResourceIDSegment.Static("staticCustomAppScopes", "customAppScopes"),
        ResourceIDSegment.UserSpecified("customAppScopeId")
    };
}
