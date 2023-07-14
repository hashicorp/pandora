using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_03_01.FluxConfigurationOperationStatus;

internal class FluxConfigurationOperationScopedId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{scope}/providers/Microsoft.KubernetesConfiguration/fluxConfigurations/{fluxConfigurationName}/operations/{operationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Scope("scope"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftKubernetesConfiguration", "Microsoft.KubernetesConfiguration"),
        ResourceIDSegment.Static("staticFluxConfigurations", "fluxConfigurations"),
        ResourceIDSegment.UserSpecified("fluxConfigurationName"),
        ResourceIDSegment.Static("staticOperations", "operations"),
        ResourceIDSegment.UserSpecified("operationId"),
    };
}
