using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagedServices.v2022_10_01.MarketplaceRegistrationDefinitions;

internal class ScopedMarketplaceRegistrationDefinitionId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{scope}/providers/Microsoft.ManagedServices/marketplaceRegistrationDefinitions/{marketplaceIdentifier}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Scope("scope"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftManagedServices", "Microsoft.ManagedServices"),
        ResourceIDSegment.Static("staticMarketplaceRegistrationDefinitions", "marketplaceRegistrationDefinitions"),
        ResourceIDSegment.UserSpecified("marketplaceIdentifier"),
    };
}
