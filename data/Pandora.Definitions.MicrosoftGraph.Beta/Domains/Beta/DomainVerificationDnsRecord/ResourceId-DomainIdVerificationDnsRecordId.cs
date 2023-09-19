// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Domains.Beta.DomainVerificationDnsRecord;

internal class DomainIdVerificationDnsRecordId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/domains/{domainId}/verificationDnsRecords/{domainDnsRecordId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticDomains", "domains"),
        ResourceIDSegment.UserSpecified("domainId"),
        ResourceIDSegment.Static("staticVerificationDnsRecords", "verificationDnsRecords"),
        ResourceIDSegment.UserSpecified("domainDnsRecordId")
    };
}
