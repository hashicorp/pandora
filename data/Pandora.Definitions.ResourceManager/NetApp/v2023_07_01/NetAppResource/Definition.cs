using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2023_07_01.NetAppResource;

internal class Definition : ResourceDefinition
{
    public string Name => "NetAppResource";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckFilePathAvailabilityOperation(),
        new CheckNameAvailabilityOperation(),
        new CheckQuotaAvailabilityOperation(),
        new QueryNetworkSiblingSetOperation(),
        new QueryRegionInfoOperation(),
        new QuotaLimitsGetOperation(),
        new QuotaLimitsListOperation(),
        new UpdateNetworkSiblingSetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CheckNameResourceTypesConstant),
        typeof(CheckQuotaNameResourceTypesConstant),
        typeof(InAvailabilityReasonTypeConstant),
        typeof(NetworkFeaturesConstant),
        typeof(NetworkSiblingSetProvisioningStateConstant),
        typeof(RegionStorageToNetworkProximityConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckAvailabilityResponseModel),
        typeof(FilePathAvailabilityRequestModel),
        typeof(NetworkSiblingSetModel),
        typeof(NicInfoModel),
        typeof(QueryNetworkSiblingSetRequestModel),
        typeof(QuotaAvailabilityRequestModel),
        typeof(RegionInfoModel),
        typeof(RegionInfoAvailabilityZoneMappingsInlinedModel),
        typeof(ResourceNameAvailabilityRequestModel),
        typeof(SubscriptionQuotaItemModel),
        typeof(SubscriptionQuotaItemListModel),
        typeof(SubscriptionQuotaItemPropertiesModel),
        typeof(UpdateNetworkSiblingSetRequestModel),
    };
}
