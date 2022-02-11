using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.ReservedInstances;

internal class BillingAccountId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.Billing/billingAccounts/{billingAccountId}";

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

    };
}
