using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2023_11_15.D4APICollectionList;

internal class Definition : ResourceDefinition
{
    public string Name => "D4APICollectionList";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new APICollectionsListByAzureApiManagementServiceOperation(),
        new APICollectionsListByResourceGroupOperation(),
        new APICollectionsListBySubscriptionOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApiCollectionModel),
        typeof(ApiCollectionPropertiesModel),
    };
}
