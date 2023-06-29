using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Authorization.v2022_04_01.ProviderOperationsMetadata;

internal class ProviderOperationId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.Authorization/providerOperations/{providerOperationName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftAuthorization", "Microsoft.Authorization"),
        ResourceIDSegment.Static("staticProviderOperations", "providerOperations"),
        ResourceIDSegment.UserSpecified("providerOperationName"),
    };
}
