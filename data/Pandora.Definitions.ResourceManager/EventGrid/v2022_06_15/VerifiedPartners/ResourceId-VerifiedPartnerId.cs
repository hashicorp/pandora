using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.VerifiedPartners;

internal class VerifiedPartnerId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.EventGrid/verifiedPartners/{verifiedPartnerName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftEventGrid", "Microsoft.EventGrid"),
        ResourceIDSegment.Static("staticVerifiedPartners", "verifiedPartners"),
        ResourceIDSegment.UserSpecified("verifiedPartnerName"),
    };
}
