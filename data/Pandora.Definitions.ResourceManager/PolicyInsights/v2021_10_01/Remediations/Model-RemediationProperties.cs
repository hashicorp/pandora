using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PolicyInsights.v2021_10_01.Remediations;


internal class RemediationPropertiesModel
{
    [JsonPropertyName("correlationId")]
    public string? CorrelationId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdOn")]
    public DateTime? CreatedOn { get; set; }

    [JsonPropertyName("deploymentStatus")]
    public RemediationDeploymentSummaryModel? DeploymentStatus { get; set; }

    [JsonPropertyName("failureThreshold")]
    public RemediationPropertiesFailureThresholdModel? FailureThreshold { get; set; }

    [JsonPropertyName("filters")]
    public RemediationFiltersModel? Filters { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdatedOn")]
    public DateTime? LastUpdatedOn { get; set; }

    [JsonPropertyName("parallelDeployments")]
    public int? ParallelDeployments { get; set; }

    [JsonPropertyName("policyAssignmentId")]
    public string? PolicyAssignmentId { get; set; }

    [JsonPropertyName("policyDefinitionReferenceId")]
    public string? PolicyDefinitionReferenceId { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("resourceCount")]
    public int? ResourceCount { get; set; }

    [JsonPropertyName("resourceDiscoveryMode")]
    public ResourceDiscoveryModeConstant? ResourceDiscoveryMode { get; set; }

    [JsonPropertyName("statusMessage")]
    public string? StatusMessage { get; set; }
}
