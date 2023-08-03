// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.ServicePrincipals.StableV1.ServicePrincipalMemberOf;

internal class MemberOfId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/servicePrincipals/{servicePrincipalId}/memberOf/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticServicePrincipals", "servicePrincipals"),
        ResourceIDSegment.UserSpecified("servicePrincipalId"),
        ResourceIDSegment.Static("staticMemberOf", "memberOf"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
