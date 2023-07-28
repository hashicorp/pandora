using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.RegistryManagement;

internal class Definition : ResourceDefinition
{
    public string Name => "RegistryManagement";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new RegistriesCreateOrUpdateOperation(),
        new RegistriesDeleteOperation(),
        new RegistriesGetOperation(),
        new RegistriesListOperation(),
        new RegistriesListBySubscriptionOperation(),
        new RegistriesRemoveRegionsOperation(),
        new RegistriesUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EndpointServiceConnectionStatusConstant),
        typeof(SkuTierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AcrDetailsModel),
        typeof(ArmResourceIdModel),
        typeof(PartialRegistryPartialTrackedResourceModel),
        typeof(PartialSkuModel),
        typeof(PrivateEndpointResourceModel),
        typeof(RegistryModel),
        typeof(RegistryPrivateEndpointConnectionModel),
        typeof(RegistryPrivateEndpointConnectionPropertiesModel),
        typeof(RegistryPrivateLinkServiceConnectionStateModel),
        typeof(RegistryRegionArmDetailsModel),
        typeof(RegistryTrackedResourceModel),
        typeof(SkuModel),
        typeof(StorageAccountDetailsModel),
        typeof(SystemCreatedAcrAccountModel),
        typeof(SystemCreatedStorageAccountModel),
        typeof(UserCreatedAcrAccountModel),
        typeof(UserCreatedStorageAccountModel),
    };
}
