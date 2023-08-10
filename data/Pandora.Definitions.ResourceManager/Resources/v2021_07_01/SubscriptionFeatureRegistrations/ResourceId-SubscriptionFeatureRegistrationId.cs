using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2021_07_01.SubscriptionFeatureRegistrations;

internal class SubscriptionFeatureRegistrationId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/providers/Microsoft.Features/featureProviders/{featureProviderName}/subscriptionFeatureRegistrations/{subscriptionFeatureRegistrationName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftFeatures", "Microsoft.Features"),
        ResourceIDSegment.Static("staticFeatureProviders", "featureProviders"),
        ResourceIDSegment.UserSpecified("featureProviderName"),
        ResourceIDSegment.Static("staticSubscriptionFeatureRegistrations", "subscriptionFeatureRegistrations"),
        ResourceIDSegment.UserSpecified("subscriptionFeatureRegistrationName"),
    };
}
