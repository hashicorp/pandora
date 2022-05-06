using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.ReservedInstances;

internal class BillingProfileId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
                new()
                {
                    Name = "staticProviders",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "providers"
                },

                new()
                {
                    Name = "staticMicrosoftBilling",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.Billing"
                },

                new()
                {
                    Name = "staticBillingAccounts",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "billingAccounts"
                },

                new()
                {
                    Name = "billingAccountId",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "staticBillingProfiles",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "billingProfiles"
                },

                new()
                {
                    Name = "billingProfileId",
                    Type = ResourceIDSegmentType.UserSpecified
                },

    };
}
