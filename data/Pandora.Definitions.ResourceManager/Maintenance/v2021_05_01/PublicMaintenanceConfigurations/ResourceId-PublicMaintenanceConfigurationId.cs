using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Maintenance.v2021_05_01.PublicMaintenanceConfigurations;

internal class PublicMaintenanceConfigurationId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/{publicMaintenanceConfigurationName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftMaintenance", "Microsoft.Maintenance"),
        ResourceIDSegment.Static("staticPublicMaintenanceConfigurations", "publicMaintenanceConfigurations"),
        ResourceIDSegment.UserSpecified("publicMaintenanceConfigurationName"),
    };
}
