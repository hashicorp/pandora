using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2022_06_01.DataCollectionRuleAssociations;

internal class Definition : ResourceDefinition
{
    public string Name => "DataCollectionRuleAssociations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByDataCollectionEndpointOperation(),
        new ListByResourceOperation(),
        new ListByRuleOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(KnownDataCollectionRuleAssociationProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DataCollectionRuleAssociationModel),
        typeof(DataCollectionRuleAssociationProxyOnlyResourceModel),
        typeof(MetadataModel),
    };
}
