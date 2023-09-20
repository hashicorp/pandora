// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryOutboundSharedUserProfileTenant;

internal class DirectoryOutboundSharedUserProfileIdTenantId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/directory/outboundSharedUserProfiles/{outboundSharedUserProfileUserId}/tenants/{tenantReferenceTenantId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticDirectory", "directory"),
        ResourceIDSegment.Static("staticOutboundSharedUserProfiles", "outboundSharedUserProfiles"),
        ResourceIDSegment.UserSpecified("outboundSharedUserProfileUserId"),
        ResourceIDSegment.Static("staticTenants", "tenants"),
        ResourceIDSegment.UserSpecified("tenantReferenceTenantId")
    };
}
