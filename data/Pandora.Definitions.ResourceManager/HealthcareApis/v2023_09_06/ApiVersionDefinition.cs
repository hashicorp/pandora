// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2023_09_06;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-09-06";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Collection.Definition(),
        new DicomServices.Definition(),
        new FhirServices.Definition(),
        new IotConnectors.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new Proxy.Definition(),
        new Resource.Definition(),
        new WorkspacePrivateEndpointConnections.Definition(),
        new WorkspacePrivateLinkResources.Definition(),
        new Workspaces.Definition(),
    };
}
