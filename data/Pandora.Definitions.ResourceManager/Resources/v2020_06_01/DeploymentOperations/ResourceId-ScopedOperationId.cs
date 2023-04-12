using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2020_06_01.DeploymentOperations;

internal class ScopedOperationId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}/operations/{operationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Scope("scope"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftResources", "Microsoft.Resources"),
        ResourceIDSegment.Static("staticDeployments", "deployments"),
        ResourceIDSegment.UserSpecified("deploymentName"),
        ResourceIDSegment.Static("staticOperations", "operations"),
        ResourceIDSegment.UserSpecified("operationId"),
    };
}
