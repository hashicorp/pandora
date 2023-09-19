// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Applications.StableV1.ApplicationSynchronizationTemplateSchemaDirectory;

internal class ApplicationIdSynchronizationTemplateIdSchemaDirectoryId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/applications/{applicationId}/synchronization/templates/{synchronizationTemplateId}/schema/directories/{directoryDefinitionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticApplications", "applications"),
        ResourceIDSegment.UserSpecified("applicationId"),
        ResourceIDSegment.Static("staticSynchronization", "synchronization"),
        ResourceIDSegment.Static("staticTemplates", "templates"),
        ResourceIDSegment.UserSpecified("synchronizationTemplateId"),
        ResourceIDSegment.Static("staticSchema", "schema"),
        ResourceIDSegment.Static("staticDirectories", "directories"),
        ResourceIDSegment.UserSpecified("directoryDefinitionId")
    };
}
