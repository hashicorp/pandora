using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.CostDetails;


internal class CostDetailsOperationResultsModel
{
    [JsonPropertyName("error")]
    public ErrorDetailsModel? Error { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("manifest")]
    public ReportManifestModel? Manifest { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("status")]
    public CostDetailsStatusTypeConstant? Status { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("validTill")]
    public DateTime? ValidTill { get; set; }
}
