using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.FrontDoors;

internal class Definition : ResourceDefinition
{
    public string Name => "FrontDoors";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new EndpointsPurgeContentOperation(),
        new FrontendEndpointsDisableHTTPSOperation(),
        new FrontendEndpointsEnableHTTPSOperation(),
        new FrontendEndpointsGetOperation(),
        new FrontendEndpointsListByFrontDoorOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new RulesEnginesCreateOrUpdateOperation(),
        new RulesEnginesDeleteOperation(),
        new RulesEnginesGetOperation(),
        new RulesEnginesListByFrontDoorOperation(),
        new ValidateCustomDomainOperation(),
    };
}
