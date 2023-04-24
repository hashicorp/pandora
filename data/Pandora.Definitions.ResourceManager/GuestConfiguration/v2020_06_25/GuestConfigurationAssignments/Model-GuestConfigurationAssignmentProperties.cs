using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.GuestConfiguration.v2020_06_25.GuestConfigurationAssignments;


internal class GuestConfigurationAssignmentPropertiesModel
{
    [JsonPropertyName("assignmentHash")]
    public string? AssignmentHash { get; set; }

    [JsonPropertyName("complianceStatus")]
    public ComplianceStatusConstant? ComplianceStatus { get; set; }

    [JsonPropertyName("context")]
    public string? Context { get; set; }

    [JsonPropertyName("guestConfiguration")]
    public GuestConfigurationNavigationModel? GuestConfiguration { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastComplianceStatusChecked")]
    public DateTime? LastComplianceStatusChecked { get; set; }

    [JsonPropertyName("latestAssignmentReport")]
    public AssignmentReportModel? LatestAssignmentReport { get; set; }

    [JsonPropertyName("latestReportId")]
    public string? LatestReportId { get; set; }

    [JsonPropertyName("parameterHash")]
    public string? ParameterHash { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("resourceType")]
    public string? ResourceType { get; set; }

    [JsonPropertyName("targetResourceId")]
    public string? TargetResourceId { get; set; }

    [JsonPropertyName("vmssVMList")]
    public List<VMSSVMInfoModel>? VMSSVMList { get; set; }
}
