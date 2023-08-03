// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ProvisioningObjectSummaryModel
{
    [JsonPropertyName("action")]
    public string? Action { get; set; }

    [JsonPropertyName("activityDateTime")]
    public DateTime? ActivityDateTime { get; set; }

    [JsonPropertyName("changeId")]
    public string? ChangeId { get; set; }

    [JsonPropertyName("cycleId")]
    public string? CycleId { get; set; }

    [JsonPropertyName("durationInMilliseconds")]
    public int? DurationInMilliseconds { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("initiatedBy")]
    public InitiatorModel? InitiatedBy { get; set; }

    [JsonPropertyName("jobId")]
    public string? JobId { get; set; }

    [JsonPropertyName("modifiedProperties")]
    public List<ModifiedPropertyModel>? ModifiedProperties { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("provisioningAction")]
    public ProvisioningActionConstant? ProvisioningAction { get; set; }

    [JsonPropertyName("provisioningStatusInfo")]
    public ProvisioningStatusInfoModel? ProvisioningStatusInfo { get; set; }

    [JsonPropertyName("provisioningSteps")]
    public List<ProvisioningStepModel>? ProvisioningSteps { get; set; }

    [JsonPropertyName("servicePrincipal")]
    public ProvisioningServicePrincipalModel? ServicePrincipal { get; set; }

    [JsonPropertyName("sourceIdentity")]
    public ProvisionedIdentityModel? SourceIdentity { get; set; }

    [JsonPropertyName("sourceSystem")]
    public ProvisioningSystemModel? SourceSystem { get; set; }

    [JsonPropertyName("statusInfo")]
    public StatusBaseModel? StatusInfo { get; set; }

    [JsonPropertyName("targetIdentity")]
    public ProvisionedIdentityModel? TargetIdentity { get; set; }

    [JsonPropertyName("targetSystem")]
    public ProvisioningSystemModel? TargetSystem { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
