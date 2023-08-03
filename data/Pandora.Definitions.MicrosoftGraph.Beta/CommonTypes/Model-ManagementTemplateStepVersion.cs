// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagementTemplateStepVersionModel
{
    [JsonPropertyName("acceptedFor")]
    public ManagementTemplateStepModel? AcceptedFor { get; set; }

    [JsonPropertyName("contentMarkdown")]
    public string? ContentMarkdown { get; set; }

    [JsonPropertyName("createdByUserId")]
    public string? CreatedByUserId { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("deployments")]
    public List<ManagementTemplateStepDeploymentModel>? Deployments { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastActionByUserId")]
    public string? LastActionByUserId { get; set; }

    [JsonPropertyName("lastActionDateTime")]
    public DateTime? LastActionDateTime { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("templateStep")]
    public ManagementTemplateStepModel? TemplateStep { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }

    [JsonPropertyName("versionInformation")]
    public string? VersionInformation { get; set; }
}
