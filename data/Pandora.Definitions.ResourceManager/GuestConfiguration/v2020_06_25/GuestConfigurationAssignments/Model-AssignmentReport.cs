using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.GuestConfiguration.v2020_06_25.GuestConfigurationAssignments;


internal class AssignmentReportModel
{
    [JsonPropertyName("assignment")]
    public AssignmentInfoModel? Assignment { get; set; }

    [JsonPropertyName("complianceStatus")]
    public ComplianceStatusConstant? ComplianceStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("operationType")]
    public TypeConstant? OperationType { get; set; }

    [JsonPropertyName("reportId")]
    public string? ReportId { get; set; }

    [JsonPropertyName("resources")]
    public List<AssignmentReportResourceModel>? Resources { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("vm")]
    public VMInfoModel? VM { get; set; }
}
