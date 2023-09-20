// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityEdiscoveryExportOperationModel
{
    [JsonPropertyName("action")]
    public SecurityEdiscoveryExportOperationActionConstant? Action { get; set; }

    [JsonPropertyName("azureBlobContainer")]
    public string? AzureBlobContainer { get; set; }

    [JsonPropertyName("azureBlobToken")]
    public string? AzureBlobToken { get; set; }

    [JsonPropertyName("completedDateTime")]
    public DateTime? CompletedDateTime { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("exportFileMetadata")]
    public List<SecurityExportFileMetadataModel>? ExportFileMetadata { get; set; }

    [JsonPropertyName("exportOptions")]
    public SecurityEdiscoveryExportOperationExportOptionsConstant? ExportOptions { get; set; }

    [JsonPropertyName("exportStructure")]
    public SecurityEdiscoveryExportOperationExportStructureConstant? ExportStructure { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("outputFolderId")]
    public string? OutputFolderId { get; set; }

    [JsonPropertyName("outputName")]
    public string? OutputName { get; set; }

    [JsonPropertyName("percentProgress")]
    public int? PercentProgress { get; set; }

    [JsonPropertyName("resultInfo")]
    public ResultInfoModel? ResultInfo { get; set; }

    [JsonPropertyName("reviewSet")]
    public SecurityEdiscoveryReviewSetModel? ReviewSet { get; set; }

    [JsonPropertyName("reviewSetQuery")]
    public SecurityEdiscoveryReviewSetQueryModel? ReviewSetQuery { get; set; }

    [JsonPropertyName("status")]
    public SecurityEdiscoveryExportOperationStatusConstant? Status { get; set; }
}
