using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01.Alerts;

internal class Definition : ResourceDefinition
{
    public string Name => "Alerts";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetResourceGroupLevelAlertsOperation(),
        new GetSubscriptionLevelAlertOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ListResourceGroupLevelAlertsByRegionOperation(),
        new ListSubscriptionLevelAlertsByRegionOperation(),
        new UpdateResourceGroupLevelAlertStateToDismissOperation(),
        new UpdateResourceGroupLevelAlertStateToReactivateOperation(),
        new UpdateSubscriptionLevelAlertStateToDismissOperation(),
        new UpdateSubscriptionLevelAlertStateToReactivateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ReportedSeverityConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AlertModel),
        typeof(AlertConfidenceReasonModel),
        typeof(AlertEntityModel),
        typeof(AlertPropertiesModel),
    };
}
