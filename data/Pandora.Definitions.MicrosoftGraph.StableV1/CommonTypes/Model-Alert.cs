// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AlertModel
{
    [JsonPropertyName("activityGroupName")]
    public string? ActivityGroupName { get; set; }

    [JsonPropertyName("alertDetections")]
    public List<AlertDetectionModel>? AlertDetections { get; set; }

    [JsonPropertyName("assignedTo")]
    public string? AssignedTo { get; set; }

    [JsonPropertyName("azureSubscriptionId")]
    public string? AzureSubscriptionId { get; set; }

    [JsonPropertyName("azureTenantId")]
    public string? AzureTenantId { get; set; }

    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("closedDateTime")]
    public DateTime? ClosedDateTime { get; set; }

    [JsonPropertyName("cloudAppStates")]
    public List<CloudAppSecurityStateModel>? CloudAppStates { get; set; }

    [JsonPropertyName("comments")]
    public List<string>? Comments { get; set; }

    [JsonPropertyName("confidence")]
    public int? Confidence { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("detectionIds")]
    public List<string>? DetectionIds { get; set; }

    [JsonPropertyName("eventDateTime")]
    public DateTime? EventDateTime { get; set; }

    [JsonPropertyName("feedback")]
    public AlertFeedbackConstant? Feedback { get; set; }

    [JsonPropertyName("fileStates")]
    public List<FileSecurityStateModel>? FileStates { get; set; }

    [JsonPropertyName("historyStates")]
    public List<AlertHistoryStateModel>? HistoryStates { get; set; }

    [JsonPropertyName("hostStates")]
    public List<HostSecurityStateModel>? HostStates { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("incidentIds")]
    public List<string>? IncidentIds { get; set; }

    [JsonPropertyName("investigationSecurityStates")]
    public List<InvestigationSecurityStateModel>? InvestigationSecurityStates { get; set; }

    [JsonPropertyName("lastEventDateTime")]
    public DateTime? LastEventDateTime { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("malwareStates")]
    public List<MalwareStateModel>? MalwareStates { get; set; }

    [JsonPropertyName("messageSecurityStates")]
    public List<MessageSecurityStateModel>? MessageSecurityStates { get; set; }

    [JsonPropertyName("networkConnections")]
    public List<NetworkConnectionModel>? NetworkConnections { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("processes")]
    public List<ProcessModel>? Processes { get; set; }

    [JsonPropertyName("recommendedActions")]
    public List<string>? RecommendedActions { get; set; }

    [JsonPropertyName("registryKeyStates")]
    public List<RegistryKeyStateModel>? RegistryKeyStates { get; set; }

    [JsonPropertyName("securityResources")]
    public List<SecurityResourceModel>? SecurityResources { get; set; }

    [JsonPropertyName("severity")]
    public AlertSeverityConstant? Severity { get; set; }

    [JsonPropertyName("sourceMaterials")]
    public List<string>? SourceMaterials { get; set; }

    [JsonPropertyName("status")]
    public AlertStatusConstant? Status { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("triggers")]
    public List<AlertTriggerModel>? Triggers { get; set; }

    [JsonPropertyName("uriClickSecurityStates")]
    public List<UriClickSecurityStateModel>? UriClickSecurityStates { get; set; }

    [JsonPropertyName("userStates")]
    public List<UserSecurityStateModel>? UserStates { get; set; }

    [JsonPropertyName("vendorInformation")]
    public SecurityVendorInformationModel? VendorInformation { get; set; }

    [JsonPropertyName("vulnerabilityStates")]
    public List<VulnerabilityStateModel>? VulnerabilityStates { get; set; }
}
