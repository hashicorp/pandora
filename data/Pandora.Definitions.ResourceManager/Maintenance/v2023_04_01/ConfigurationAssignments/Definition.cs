using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Maintenance.v2023_04_01.ConfigurationAssignments;

internal class Definition : ResourceDefinition
{
    public string Name => "ConfigurationAssignments";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new CreateOrUpdateParentOperation(),
        new DeleteOperation(),
        new DeleteParentOperation(),
        new ForResourceGroupCreateOrUpdateOperation(),
        new ForResourceGroupDeleteOperation(),
        new ForResourceGroupGetOperation(),
        new ForResourceGroupUpdateOperation(),
        new ForSubscriptionsCreateOrUpdateOperation(),
        new ForSubscriptionsDeleteOperation(),
        new ForSubscriptionsGetOperation(),
        new ForSubscriptionsUpdateOperation(),
        new GetOperation(),
        new GetParentOperation(),
        new ListOperation(),
        new ListParentOperation(),
        new WithinSubscriptionListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(TagOperatorsConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ConfigurationAssignmentModel),
        typeof(ConfigurationAssignmentFilterPropertiesModel),
        typeof(ConfigurationAssignmentPropertiesModel),
        typeof(ListConfigurationAssignmentsResultModel),
        typeof(TagSettingsPropertiesModel),
    };
}
