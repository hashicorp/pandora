using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WorkflowTriggers;

internal class Definition : ResourceDefinition
{
    public string Name => "WorkflowTriggers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new GetSchemaJsonOperation(),
        new ListOperation(),
        new ListCallbackUrlOperation(),
        new RunOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DayOfWeekConstant),
        typeof(DaysOfWeekConstant),
        typeof(RecurrenceFrequencyConstant),
        typeof(WorkflowStateConstant),
        typeof(WorkflowStatusConstant),
        typeof(WorkflowTriggerProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(JsonSchemaModel),
        typeof(RecurrenceScheduleModel),
        typeof(RecurrenceScheduleOccurrenceModel),
        typeof(ResourceReferenceModel),
        typeof(WorkflowTriggerModel),
        typeof(WorkflowTriggerCallbackUrlModel),
        typeof(WorkflowTriggerListCallbackUrlQueriesModel),
        typeof(WorkflowTriggerPropertiesModel),
        typeof(WorkflowTriggerRecurrenceModel),
    };
}
