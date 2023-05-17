using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_11_01.AzureFirewalls;

internal class Definition : ResourceDefinition
{
    public string Name => "AzureFirewalls";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AzureFirewallsListLearnedPrefixesOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListAllOperation(),
        new PacketCaptureOperation(),
        new UpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AzureFirewallApplicationRuleProtocolTypeConstant),
        typeof(AzureFirewallNatRCActionTypeConstant),
        typeof(AzureFirewallNetworkRuleProtocolConstant),
        typeof(AzureFirewallPacketCaptureFlagsTypeConstant),
        typeof(AzureFirewallRCActionTypeConstant),
        typeof(AzureFirewallSkuNameConstant),
        typeof(AzureFirewallSkuTierConstant),
        typeof(AzureFirewallThreatIntelModeConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureFirewallModel),
        typeof(AzureFirewallApplicationRuleModel),
        typeof(AzureFirewallApplicationRuleCollectionModel),
        typeof(AzureFirewallApplicationRuleCollectionPropertiesFormatModel),
        typeof(AzureFirewallApplicationRuleProtocolModel),
        typeof(AzureFirewallIPConfigurationModel),
        typeof(AzureFirewallIPConfigurationPropertiesFormatModel),
        typeof(AzureFirewallIPGroupsModel),
        typeof(AzureFirewallNatRCActionModel),
        typeof(AzureFirewallNatRuleModel),
        typeof(AzureFirewallNatRuleCollectionModel),
        typeof(AzureFirewallNatRuleCollectionPropertiesModel),
        typeof(AzureFirewallNetworkRuleModel),
        typeof(AzureFirewallNetworkRuleCollectionModel),
        typeof(AzureFirewallNetworkRuleCollectionPropertiesFormatModel),
        typeof(AzureFirewallPacketCaptureFlagsModel),
        typeof(AzureFirewallPacketCaptureRuleModel),
        typeof(AzureFirewallPropertiesFormatModel),
        typeof(AzureFirewallPublicIPAddressModel),
        typeof(AzureFirewallRCActionModel),
        typeof(AzureFirewallSkuModel),
        typeof(FirewallPacketCaptureParametersModel),
        typeof(FirewallPacketCaptureParametersFormatModel),
        typeof(HubIPAddressesModel),
        typeof(HubPublicIPAddressesModel),
        typeof(IPPrefixesListModel),
        typeof(SubResourceModel),
        typeof(TagsObjectModel),
    };
}
