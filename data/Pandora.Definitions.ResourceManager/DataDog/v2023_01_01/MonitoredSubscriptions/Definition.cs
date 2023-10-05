using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataDog.v2023_01_01.MonitoredSubscriptions;

internal class Definition : ResourceDefinition
{
    public string Name => "MonitoredSubscriptions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateorUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(OperationConstant),
        typeof(ProvisioningStateConstant),
        typeof(StatusConstant),
        typeof(TagActionConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(FilteringTagModel),
        typeof(LogRulesModel),
        typeof(MetricRulesModel),
        typeof(MonitoredSubscriptionModel),
        typeof(MonitoredSubscriptionPropertiesModel),
        typeof(MonitoredSubscriptionPropertiesListModel),
        typeof(MonitoringTagRulesPropertiesModel),
        typeof(SubscriptionListModel),
    };
}
