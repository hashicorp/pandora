using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01.ReservationRecommendationDetails;

internal class BillingScopeId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{billingScope}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.UserSpecified("billingScope"),
    };
}
