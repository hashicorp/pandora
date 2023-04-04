using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2019_10_17_preview.PrivateLinkScopesAPIs;

internal class Definition : ResourceDefinition
{
    public string Name => "PrivateLinkScopesAPIs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new PrivateLinkScopesCreateOrUpdateOperation(),
        new PrivateLinkScopesDeleteOperation(),
        new PrivateLinkScopesGetOperation(),
        new PrivateLinkScopesListOperation(),
        new PrivateLinkScopesListByResourceGroupOperation(),
        new PrivateLinkScopesUpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureMonitorPrivateLinkScopeModel),
        typeof(AzureMonitorPrivateLinkScopePropertiesModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateEndpointPropertyModel),
        typeof(PrivateLinkServiceConnectionStatePropertyModel),
        typeof(TagsResourceModel),
    };
}
