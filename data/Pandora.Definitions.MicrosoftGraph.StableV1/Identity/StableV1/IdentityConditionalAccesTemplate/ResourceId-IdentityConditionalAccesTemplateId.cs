// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityConditionalAccesTemplate;

internal class IdentityConditionalAccesTemplateId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/identity/conditionalAccess/templates/{conditionalAccessTemplateId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticIdentity", "identity"),
        ResourceIDSegment.Static("staticConditionalAccess", "conditionalAccess"),
        ResourceIDSegment.Static("staticTemplates", "templates"),
        ResourceIDSegment.UserSpecified("conditionalAccessTemplateId")
    };
}
