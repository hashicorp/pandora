using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CustomProviders.v2018_09_01_preview.CustomResourceProvider;

internal class Definition : ResourceDefinition
{
    public string Name => "CustomResourceProvider";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ActionRoutingConstant),
        typeof(ProvisioningStateConstant),
        typeof(ResourceTypeRoutingConstant),
        typeof(ValidationTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CustomRPActionRouteDefinitionModel),
        typeof(CustomRPManifestModel),
        typeof(CustomRPManifestPropertiesModel),
        typeof(CustomRPResourceTypeRouteDefinitionModel),
        typeof(CustomRPValidationsModel),
        typeof(ResourceProvidersUpdateModel),
    };
}
