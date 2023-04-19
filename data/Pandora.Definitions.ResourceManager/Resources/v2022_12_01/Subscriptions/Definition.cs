using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_12_01.Subscriptions;

internal class Definition : ResourceDefinition
{
    public string Name => "Subscriptions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckZonePeersOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListLocationsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(LocationTypeConstant),
        typeof(RegionCategoryConstant),
        typeof(RegionTypeConstant),
        typeof(SpendingLimitConstant),
        typeof(SubscriptionStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AvailabilityZoneMappingsModel),
        typeof(AvailabilityZonePeersModel),
        typeof(CheckZonePeersRequestModel),
        typeof(CheckZonePeersResultModel),
        typeof(LocationModel),
        typeof(LocationListResultModel),
        typeof(LocationMetadataModel),
        typeof(ManagedByTenantModel),
        typeof(PairedRegionModel),
        typeof(PeersModel),
        typeof(SubscriptionModel),
        typeof(SubscriptionPoliciesModel),
    };
}
