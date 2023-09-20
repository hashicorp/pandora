// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Applications.Beta.ApplicationSynchronizationTemplateSchema;

internal class ApplicationIdSynchronizationTemplateId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/applications/{applicationId}/synchronization/templates/{synchronizationTemplateId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticApplications", "applications"),
        ResourceIDSegment.UserSpecified("applicationId"),
        ResourceIDSegment.Static("staticSynchronization", "synchronization"),
        ResourceIDSegment.Static("staticTemplates", "templates"),
        ResourceIDSegment.UserSpecified("synchronizationTemplateId")
    };
}
