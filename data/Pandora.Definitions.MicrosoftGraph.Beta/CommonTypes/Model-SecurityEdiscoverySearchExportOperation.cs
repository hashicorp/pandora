// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityEdiscoverySearchExportOperationModel
{
    [JsonPropertyName("action")]
    public SecurityEdiscoverySearchExportOperationActionConstant? Action { get; set; }

    [JsonPropertyName("additionalOptions")]
    public SecurityEdiscoverySearchExportOperationAdditionalOptionsConstant? AdditionalOptions { get; set; }

    [JsonPropertyName("completedDateTime")]
    public DateTime? CompletedDateTime { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("exportCriteria")]
    public SecurityEdiscoverySearchExportOperationExportCriteriaConstant? ExportCriteria { get; set; }

    [JsonPropertyName("exportFileMetadata")]
    public List<SecurityExportFileMetadataModel>? ExportFileMetadata { get; set; }

    [JsonPropertyName("exportFormat")]
    public SecurityEdiscoverySearchExportOperationExportFormatConstant? ExportFormat { get; set; }

    [JsonPropertyName("exportLocation")]
    public SecurityEdiscoverySearchExportOperationExportLocationConstant? ExportLocation { get; set; }

    [JsonPropertyName("exportSingleItems")]
    public bool? ExportSingleItems { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("percentProgress")]
    public int? PercentProgress { get; set; }

    [JsonPropertyName("resultInfo")]
    public ResultInfoModel? ResultInfo { get; set; }

    [JsonPropertyName("search")]
    public SecurityEdiscoverySearchModel? Search { get; set; }

    [JsonPropertyName("status")]
    public SecurityEdiscoverySearchExportOperationStatusConstant? Status { get; set; }
}
