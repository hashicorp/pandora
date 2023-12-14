// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.ApplicationTemplates.StableV1.ApplicationTemplate;

internal class ApplicationTemplateId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/applicationTemplates/{applicationTemplateId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticApplicationTemplates", "applicationTemplates"),
        ResourceIDSegment.UserSpecified("applicationTemplateId")
    };
}
