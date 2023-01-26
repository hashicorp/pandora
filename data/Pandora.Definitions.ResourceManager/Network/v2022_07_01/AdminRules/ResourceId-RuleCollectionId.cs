using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.AdminRules;

internal class RuleCollectionId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkManagers/{networkManagerName}/securityAdminConfigurations/{securityAdminConfigurationName}/ruleCollections/{ruleCollectionName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftNetwork", "Microsoft.Network"),
        ResourceIDSegment.Static("staticNetworkManagers", "networkManagers"),
        ResourceIDSegment.UserSpecified("networkManagerName"),
        ResourceIDSegment.Static("staticSecurityAdminConfigurations", "securityAdminConfigurations"),
        ResourceIDSegment.UserSpecified("securityAdminConfigurationName"),
        ResourceIDSegment.Static("staticRuleCollections", "ruleCollections"),
        ResourceIDSegment.UserSpecified("ruleCollectionName"),
    };
}
