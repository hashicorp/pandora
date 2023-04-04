using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.IoTCentral.v2021_11_01_preview.Apps;

internal class Definition : ResourceDefinition
{
    public string Name => "Apps";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CheckSubdomainAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListTemplatesOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AppSkuConstant),
        typeof(AppStateConstant),
        typeof(IPRuleActionConstant),
        typeof(NetworkActionConstant),
        typeof(PrivateEndpointConnectionProvisioningStateConstant),
        typeof(PrivateEndpointServiceConnectionStatusConstant),
        typeof(ProvisioningStateConstant),
        typeof(PublicNetworkAccessConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AppModel),
        typeof(AppAvailabilityInfoModel),
        typeof(AppPatchModel),
        typeof(AppPropertiesModel),
        typeof(AppSkuInfoModel),
        typeof(AppTemplateModel),
        typeof(AppTemplateLocationsModel),
        typeof(NetworkRuleSetIPRuleModel),
        typeof(NetworkRuleSetsModel),
        typeof(OperationInputsModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateLinkServiceConnectionStateModel),
    };
}
