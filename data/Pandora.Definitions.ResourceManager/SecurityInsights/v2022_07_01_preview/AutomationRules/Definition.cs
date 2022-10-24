using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.AutomationRules;

internal class Definition : ResourceDefinition
{
    public string Name => "AutomationRules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AutomationRulesCreateOrUpdateOperation(),
        new AutomationRulesDeleteOperation(),
        new AutomationRulesGetOperation(),
        new AutomationRulesListOperation(),
    };
}
