using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountBatchConfigurations;

internal class Definition : ResourceDefinition
{
    public string Name => "IntegrationAccountBatchConfigurations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DayOfWeekConstant),
        typeof(DaysOfWeekConstant),
        typeof(RecurrenceFrequencyConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BatchConfigurationModel),
        typeof(BatchConfigurationCollectionModel),
        typeof(BatchConfigurationPropertiesModel),
        typeof(BatchReleaseCriteriaModel),
        typeof(RecurrenceScheduleModel),
        typeof(RecurrenceScheduleOccurrenceModel),
        typeof(WorkflowTriggerRecurrenceModel),
    };
}
