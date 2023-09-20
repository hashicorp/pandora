// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Applications.Beta.ApplicationSynchronizationJobSchemaDirectory;

internal class ApplicationIdSynchronizationJobIdSchemaDirectoryId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/applications/{applicationId}/synchronization/jobs/{synchronizationJobId}/schema/directories/{directoryDefinitionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticApplications", "applications"),
        ResourceIDSegment.UserSpecified("applicationId"),
        ResourceIDSegment.Static("staticSynchronization", "synchronization"),
        ResourceIDSegment.Static("staticJobs", "jobs"),
        ResourceIDSegment.UserSpecified("synchronizationJobId"),
        ResourceIDSegment.Static("staticSchema", "schema"),
        ResourceIDSegment.Static("staticDirectories", "directories"),
        ResourceIDSegment.UserSpecified("directoryDefinitionId")
    };
}
