using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2023_03_01.PrometheusRuleGroups;

internal class Definition : ResourceDefinition
{
    public string Name => "PrometheusRuleGroups";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(PrometheusRuleModel),
        typeof(PrometheusRuleGroupActionModel),
        typeof(PrometheusRuleGroupPropertiesModel),
        typeof(PrometheusRuleGroupResourceModel),
        typeof(PrometheusRuleGroupResourceCollectionModel),
        typeof(PrometheusRuleGroupResourcePatchParametersModel),
        typeof(PrometheusRuleGroupResourcePatchParametersPropertiesModel),
        typeof(PrometheusRuleResolveConfigurationModel),
    };
}
