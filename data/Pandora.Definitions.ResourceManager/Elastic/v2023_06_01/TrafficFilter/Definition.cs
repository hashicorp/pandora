using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Elastic.v2023_06_01.TrafficFilter;

internal class Definition : ResourceDefinition
{
    public string Name => "TrafficFilter";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AllTrafficFilterslistOperation(),
        new AssociateTrafficFilterAssociateOperation(),
        new CreateAndAssociateIPFilterCreateOperation(),
        new CreateAndAssociatePLFilterCreateOperation(),
        new DeleteOperation(),
        new DetachAndDeleteTrafficFilterDeleteOperation(),
        new DetachTrafficFilterUpdateOperation(),
        new ListAssociatedTrafficFilterslistOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(TypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ElasticTrafficFilterModel),
        typeof(ElasticTrafficFilterResponseModel),
        typeof(ElasticTrafficFilterRuleModel),
    };
}
