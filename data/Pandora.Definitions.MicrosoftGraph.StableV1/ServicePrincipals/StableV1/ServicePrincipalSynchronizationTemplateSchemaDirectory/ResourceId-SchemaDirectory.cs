// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.ServicePrincipals.StableV1.ServicePrincipalSynchronizationTemplateSchemaDirectory;

internal class SchemaDirectoryId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/servicePrincipals/{servicePrincipalId}/synchronization/templates/{synchronizationTemplateId}/schema/directories/{directoryDefinitionId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticServicePrincipals", "servicePrincipals"),
        ResourceIDSegment.UserSpecified("servicePrincipalId"),
        ResourceIDSegment.Static("staticSynchronization", "synchronization"),
        ResourceIDSegment.Static("staticTemplates", "templates"),
        ResourceIDSegment.UserSpecified("synchronizationTemplateId"),
        ResourceIDSegment.Static("staticSchema", "schema"),
        ResourceIDSegment.Static("staticDirectories", "directories"),
        ResourceIDSegment.UserSpecified("directoryDefinitionId")
    };
}
