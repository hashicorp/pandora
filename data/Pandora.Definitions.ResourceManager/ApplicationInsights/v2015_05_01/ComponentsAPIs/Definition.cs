using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.ComponentsAPIs;

internal class Definition : ResourceDefinition
{
    public string Name => "ComponentsAPIs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ComponentsCreateOrUpdateOperation(),
        new ComponentsDeleteOperation(),
        new ComponentsGetOperation(),
        new ComponentsGetPurgeStatusOperation(),
        new ComponentsListOperation(),
        new ComponentsListByResourceGroupOperation(),
        new ComponentsPurgeOperation(),
        new ComponentsUpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ApplicationTypeConstant),
        typeof(FlowTypeConstant),
        typeof(IngestionModeConstant),
        typeof(PurgeStateConstant),
        typeof(RequestSourceConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApplicationInsightsComponentModel),
        typeof(ApplicationInsightsComponentPropertiesModel),
        typeof(ComponentPurgeBodyModel),
        typeof(ComponentPurgeBodyFiltersModel),
        typeof(ComponentPurgeResponseModel),
        typeof(ComponentPurgeStatusResponseModel),
        typeof(PrivateLinkScopedResourceModel),
        typeof(TagsResourceModel),
    };
}
