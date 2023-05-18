using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_11_01.FirewallPolicies;

internal class Definition : ResourceDefinition
{
    public string Name => "FirewallPolicies";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new FirewallPolicyIdpsSignaturesFilterValuesListOperation(),
        new FirewallPolicyIdpsSignaturesListOperation(),
        new FirewallPolicyIdpsSignaturesOverridesGetOperation(),
        new FirewallPolicyIdpsSignaturesOverridesListOperation(),
        new FirewallPolicyIdpsSignaturesOverridesPatchOperation(),
        new FirewallPolicyIdpsSignaturesOverridesPutOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListAllOperation(),
        new UpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AutoLearnPrivateRangesModeConstant),
        typeof(AzureFirewallThreatIntelModeConstant),
        typeof(FirewallPolicyIDPSQuerySortOrderConstant),
        typeof(FirewallPolicyIDPSSignatureDirectionConstant),
        typeof(FirewallPolicyIDPSSignatureModeConstant),
        typeof(FirewallPolicyIDPSSignatureSeverityConstant),
        typeof(FirewallPolicyIntrusionDetectionProtocolConstant),
        typeof(FirewallPolicyIntrusionDetectionStateTypeConstant),
        typeof(FirewallPolicySkuTierConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DnsSettingsModel),
        typeof(ExplicitProxyModel),
        typeof(FilterItemsModel),
        typeof(FirewallPolicyModel),
        typeof(FirewallPolicyCertificateAuthorityModel),
        typeof(FirewallPolicyInsightsModel),
        typeof(FirewallPolicyIntrusionDetectionModel),
        typeof(FirewallPolicyIntrusionDetectionBypassTrafficSpecificationsModel),
        typeof(FirewallPolicyIntrusionDetectionConfigurationModel),
        typeof(FirewallPolicyIntrusionDetectionSignatureSpecificationModel),
        typeof(FirewallPolicyLogAnalyticsResourcesModel),
        typeof(FirewallPolicyLogAnalyticsWorkspaceModel),
        typeof(FirewallPolicyPropertiesFormatModel),
        typeof(FirewallPolicySNATModel),
        typeof(FirewallPolicySQLModel),
        typeof(FirewallPolicySkuModel),
        typeof(FirewallPolicyThreatIntelWhitelistModel),
        typeof(FirewallPolicyTransportSecurityModel),
        typeof(IDPSQueryObjectModel),
        typeof(OrderByModel),
        typeof(QueryResultsModel),
        typeof(SignatureOverridesFilterValuesQueryModel),
        typeof(SignatureOverridesFilterValuesResponseModel),
        typeof(SignaturesOverridesModel),
        typeof(SignaturesOverridesListModel),
        typeof(SignaturesOverridesPropertiesModel),
        typeof(SingleQueryResultModel),
        typeof(SubResourceModel),
        typeof(TagsObjectModel),
    };
}
