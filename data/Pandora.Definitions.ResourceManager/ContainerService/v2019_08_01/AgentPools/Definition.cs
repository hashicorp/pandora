using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2019_08_01.AgentPools;

internal class Definition : ResourceDefinition
{
    public string Name => "AgentPools";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetAvailableAgentPoolVersionsOperation(),
        new GetUpgradeProfileOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ContainerServiceOSTypesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AgentPoolModel),
        typeof(AgentPoolAvailableVersionsModel),
        typeof(AgentPoolAvailableVersionsPropertiesModel),
        typeof(AgentPoolAvailableVersionsPropertiesAgentPoolVersionsInlinedModel),
        typeof(AgentPoolUpgradeProfileModel),
        typeof(AgentPoolUpgradeProfilePropertiesModel),
        typeof(AgentPoolUpgradeProfilePropertiesUpgradesInlinedModel),
    };
}
