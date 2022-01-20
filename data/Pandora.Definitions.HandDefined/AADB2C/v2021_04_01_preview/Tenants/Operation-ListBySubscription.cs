using System;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.HandDefined.AADB2C.v2021_04_01_preview.Tenants;

public class ListBySubscription : ListOperation
{
    public override Type NestedItemType()
    {
        return typeof(TenantModel);
    }

    public override ResourceID? ResourceId()
    {
        return new SubscriptionId();
    }

    public override string? UriSuffix()
    {
        return "/providers/Microsoft.AzureActiveDirectory/b2cDirectories";
    }
}