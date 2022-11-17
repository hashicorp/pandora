using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PolicyInsights.v2022_09_01.Attestations;

internal class ScopedAttestationId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{resourceId}/providers/Microsoft.PolicyInsights/attestations/{attestationName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Scope("resourceId"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftPolicyInsights", "Microsoft.PolicyInsights"),
        ResourceIDSegment.Static("staticAttestations", "attestations"),
        ResourceIDSegment.UserSpecified("attestationName"),
    };
}
