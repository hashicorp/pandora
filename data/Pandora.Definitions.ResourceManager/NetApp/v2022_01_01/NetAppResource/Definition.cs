using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2022_01_01.NetAppResource;

internal class Definition : ResourceDefinition
{
    public string Name => "NetAppResource";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new NetAppResourceCheckFilePathAvailabilityOperation(),
        new NetAppResourceCheckNameAvailabilityOperation(),
        new NetAppResourceCheckQuotaAvailabilityOperation(),
        new NetAppResourceQuotaLimitsGetOperation(),
        new NetAppResourceQuotaLimitsListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CheckNameResourceTypesConstant),
        typeof(CheckQuotaNameResourceTypesConstant),
        typeof(InAvailabilityReasonTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckAvailabilityResponseModel),
        typeof(FilePathAvailabilityRequestModel),
        typeof(QuotaAvailabilityRequestModel),
        typeof(ResourceNameAvailabilityRequestModel),
        typeof(SubscriptionQuotaItemModel),
        typeof(SubscriptionQuotaItemListModel),
        typeof(SubscriptionQuotaItemPropertiesModel),
    };
}
