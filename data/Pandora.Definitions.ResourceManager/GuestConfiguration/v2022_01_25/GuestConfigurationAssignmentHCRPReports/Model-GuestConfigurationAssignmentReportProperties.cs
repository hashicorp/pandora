using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.GuestConfiguration.v2022_01_25.GuestConfigurationAssignmentHCRPReports;


internal class GuestConfigurationAssignmentReportPropertiesModel
{
    [JsonPropertyName("assignment")]
    public AssignmentInfoModel? Assignment { get; set; }

    [JsonPropertyName("complianceStatus")]
    public ComplianceStatusConstant? ComplianceStatus { get; set; }

    [JsonPropertyName("details")]
    public AssignmentReportDetailsModel? Details { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; set; }

    [JsonPropertyName("reportId")]
    public string? ReportId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("vm")]
    public VMInfoModel? VM { get; set; }

    [JsonPropertyName("vmssResourceId")]
    public string? VMSSResourceId { get; set; }
}
