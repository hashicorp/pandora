using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2021_08_08.AlertProcessingRules;

internal class Definition : ResourceDefinition
{
    public string Name => "AlertProcessingRules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AlertProcessingRulesCreateOrUpdateOperation(),
        new AlertProcessingRulesDeleteOperation(),
        new AlertProcessingRulesGetByNameOperation(),
        new AlertProcessingRulesListByResourceGroupOperation(),
        new AlertProcessingRulesListBySubscriptionOperation(),
        new AlertProcessingRulesUpdateOperation(),
    };
}
