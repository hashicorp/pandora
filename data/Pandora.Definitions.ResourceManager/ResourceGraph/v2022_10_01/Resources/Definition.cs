using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ResourceGraph.v2022_10_01.Resources;

internal class Definition : ResourceDefinition
{
    public string Name => "Resources";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ResourcesOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AuthorizationScopeFilterConstant),
        typeof(FacetSortOrderConstant),
        typeof(ResultFormatConstant),
        typeof(ResultTruncatedConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ErrorDetailsModel),
        typeof(FacetModel),
        typeof(FacetErrorModel),
        typeof(FacetRequestModel),
        typeof(FacetRequestOptionsModel),
        typeof(FacetResultModel),
        typeof(QueryRequestModel),
        typeof(QueryRequestOptionsModel),
        typeof(QueryResponseModel),
    };
}
