using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountPartners;

internal class Definition : ResourceDefinition
{
    public string Name => "IntegrationAccountPartners";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListContentCallbackUrlOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(KeyTypeConstant),
        typeof(PartnerTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(B2BPartnerContentModel),
        typeof(BusinessIdentityModel),
        typeof(GetCallbackUrlParametersModel),
        typeof(IntegrationAccountPartnerModel),
        typeof(IntegrationAccountPartnerPropertiesModel),
        typeof(PartnerContentModel),
        typeof(WorkflowTriggerCallbackUrlModel),
        typeof(WorkflowTriggerListCallbackUrlQueriesModel),
    };
}
