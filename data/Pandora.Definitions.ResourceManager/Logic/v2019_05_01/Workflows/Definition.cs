using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.Workflows;

internal class Definition : ResourceDefinition
{
    public string Name => "Workflows";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new DisableOperation(),
        new EnableOperation(),
        new GenerateUpgradedDefinitionOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListCallbackUrlOperation(),
        new ListSwaggerOperation(),
        new MoveOperation(),
        new RegenerateAccessKeyOperation(),
        new UpdateOperation(),
        new ValidateByLocationOperation(),
        new ValidateByResourceGroupOperation(),
    };
}
