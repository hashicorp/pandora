using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.GuestConfiguration.v2022_01_25.GuestConfigurationConnectedVMwarevSphereAssignments;


internal class VMSSVMInfoModel
{
    [JsonPropertyName("complianceStatus")]
    public ComplianceStatusConstant? ComplianceStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastComplianceChecked")]
    public DateTime? LastComplianceChecked { get; set; }

    [JsonPropertyName("latestReportId")]
    public string? LatestReportId { get; set; }

    [JsonPropertyName("vmId")]
    public string? VMId { get; set; }

    [JsonPropertyName("vmResourceId")]
    public string? VMResourceId { get; set; }
}
