using System;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.HandDefined.AADB2C.v2021_04_01_preview.Tenants;

public class CheckNameAvailabilityOperation : PostOperation
{
    public override Type? RequestObject()
    {
        return typeof(CheckNameAvailabilityRequestModel);
    }

    public override Type? ResponseObject()
    {
        return typeof(CheckNameAvailabilityResultModel);
    }

    public override ResourceID? ResourceId()
    {
        return new SubscriptionId();
    }

    public override string? UriSuffix()
    {
        return "/providers/Microsoft.AzureActiveDirectory/checkNameAvailability";
    }
}