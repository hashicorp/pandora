using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_08_01.AlertRules;

internal class Definition : ResourceDefinition
{
    public string Name => "AlertRules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AlertRulesCreateOrUpdateOperation(),
        new AlertRulesDeleteOperation(),
        new AlertRulesGetOperation(),
        new AlertRulesListOperation(),
    };
}
