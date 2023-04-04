using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.WorkflowTriggers;

internal class Definition : ResourceDefinition
{
    public string Name => "WorkflowTriggers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new GetSchemaJsonOperation(),
        new ListOperation(),
        new ListCallbackUrlOperation(),
        new ResetOperation(),
        new RunOperation(),
        new SetStateOperation(),
        new WorkflowVersionTriggersListCallbackUrlOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DayOfWeekConstant),
        typeof(DaysOfWeekConstant),
        typeof(KeyTypeConstant),
        typeof(RecurrenceFrequencyConstant),
        typeof(WorkflowStateConstant),
        typeof(WorkflowStatusConstant),
        typeof(WorkflowTriggerProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(GetCallbackUrlParametersModel),
        typeof(JsonSchemaModel),
        typeof(RecurrenceScheduleModel),
        typeof(RecurrenceScheduleOccurrenceModel),
        typeof(ResourceReferenceModel),
        typeof(SetTriggerStateActionDefinitionModel),
        typeof(WorkflowTriggerModel),
        typeof(WorkflowTriggerCallbackUrlModel),
        typeof(WorkflowTriggerListCallbackUrlQueriesModel),
        typeof(WorkflowTriggerPropertiesModel),
        typeof(WorkflowTriggerRecurrenceModel),
        typeof(WorkflowTriggerReferenceModel),
    };
}
