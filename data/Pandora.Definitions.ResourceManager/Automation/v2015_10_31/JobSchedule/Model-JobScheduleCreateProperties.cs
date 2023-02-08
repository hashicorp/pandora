using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2015_10_31.JobSchedule;


internal class JobScheduleCreatePropertiesModel
{
    [JsonPropertyName("parameters")]
    public Dictionary<string, string>? Parameters { get; set; }

    [JsonPropertyName("runOn")]
    public string? RunOn { get; set; }

    [JsonPropertyName("runbook")]
    [Required]
    public RunbookAssociationPropertyModel Runbook { get; set; }

    [JsonPropertyName("schedule")]
    [Required]
    public ScheduleAssociationPropertyModel Schedule { get; set; }
}
