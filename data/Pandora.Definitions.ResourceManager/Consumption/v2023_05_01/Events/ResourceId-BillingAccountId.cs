using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2023_05_01.Events;

internal class BillingAccountId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.Billing/billingAccounts/{billingAccountId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftBilling", "Microsoft.Billing"),
        ResourceIDSegment.Static("staticBillingAccounts", "billingAccounts"),
        ResourceIDSegment.UserSpecified("billingAccountId"),
    };
}
