using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.SecurityRules;

internal class Definition : ResourceDefinition
{
    public string Name => "SecurityRules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DefaultSecurityRulesGetOperation(),
        new DefaultSecurityRulesListOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
}
