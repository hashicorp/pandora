// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.ServicePrincipals.Beta.ServicePrincipalSynchronizationJobSchemaDirectory;

internal class ServicePrincipalIdSynchronizationJobIdSchemaDirectoryId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/servicePrincipals/{servicePrincipalId}/synchronization/jobs/{synchronizationJobId}/schema/directories/{directoryDefinitionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticServicePrincipals", "servicePrincipals"),
        ResourceIDSegment.UserSpecified("servicePrincipalId"),
        ResourceIDSegment.Static("staticSynchronization", "synchronization"),
        ResourceIDSegment.Static("staticJobs", "jobs"),
        ResourceIDSegment.UserSpecified("synchronizationJobId"),
        ResourceIDSegment.Static("staticSchema", "schema"),
        ResourceIDSegment.Static("staticDirectories", "directories"),
        ResourceIDSegment.UserSpecified("directoryDefinitionId")
    };
}
