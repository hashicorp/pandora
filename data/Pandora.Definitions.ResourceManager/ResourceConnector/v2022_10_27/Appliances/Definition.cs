using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ResourceConnector.v2022_10_27.Appliances;

internal class Definition : ResourceDefinition
{
    public string Name => "Appliances";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetTelemetryConfigOperation(),
        new GetUpgradeGraphOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListClusterUserCredentialOperation(),
        new ListKeysOperation(),
        new UpdateOperation(),
    };
}
