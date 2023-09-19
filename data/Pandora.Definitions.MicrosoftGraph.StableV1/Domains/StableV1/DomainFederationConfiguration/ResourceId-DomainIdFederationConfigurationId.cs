// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Domains.StableV1.DomainFederationConfiguration;

internal class DomainIdFederationConfigurationId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/domains/{domainId}/federationConfiguration/{internalDomainFederationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticDomains", "domains"),
        ResourceIDSegment.UserSpecified("domainId"),
        ResourceIDSegment.Static("staticFederationConfiguration", "federationConfiguration"),
        ResourceIDSegment.UserSpecified("internalDomainFederationId")
    };
}
