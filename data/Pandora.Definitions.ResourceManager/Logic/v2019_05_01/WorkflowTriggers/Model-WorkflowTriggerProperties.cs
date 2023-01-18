using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.WorkflowTriggers;


internal class WorkflowTriggerPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("changedTime")]
    public DateTime? ChangedTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdTime")]
    public DateTime? CreatedTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastExecutionTime")]
    public DateTime? LastExecutionTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("nextExecutionTime")]
    public DateTime? NextExecutionTime { get; set; }

    [JsonPropertyName("provisioningState")]
    public WorkflowTriggerProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("recurrence")]
    public WorkflowTriggerRecurrenceModel? Recurrence { get; set; }

    [JsonPropertyName("state")]
    public WorkflowStateConstant? State { get; set; }

    [JsonPropertyName("status")]
    public WorkflowStatusConstant? Status { get; set; }

    [JsonPropertyName("workflow")]
    public ResourceReferenceModel? Workflow { get; set; }
}
