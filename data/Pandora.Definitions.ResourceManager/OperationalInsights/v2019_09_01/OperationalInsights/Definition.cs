using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2019_09_01.OperationalInsights;

internal class Definition : ResourceDefinition
{
    public string Name => "OperationalInsights";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new QueriesDeleteOperation(),
        new QueriesGetOperation(),
        new QueriesListOperation(),
        new QueriesPutOperation(),
        new QueriesSearchOperation(),
        new QueriesUpdateOperation(),
        new QueryPacksCreateOrUpdateOperation(),
        new QueryPacksDeleteOperation(),
        new QueryPacksGetOperation(),
        new QueryPacksListOperation(),
        new QueryPacksListByResourceGroupOperation(),
        new QueryPacksUpdateTagsOperation(),
    };
}
