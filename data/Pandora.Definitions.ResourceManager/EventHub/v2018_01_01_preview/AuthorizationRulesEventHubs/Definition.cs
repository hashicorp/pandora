using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.AuthorizationRulesEventHubs;

internal class Definition : ResourceDefinition
{
    public string Name => "AuthorizationRulesEventHubs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new EventHubsCreateOrUpdateAuthorizationRuleOperation(),
        new EventHubsListAuthorizationRulesOperation(),
        new EventHubsListKeysOperation(),
        new EventHubsRegenerateKeysOperation(),
    };
}
