// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsUpdatesQualityUpdateCatalogEntryModel
{
    [JsonPropertyName("catalogName")]
    public string? CatalogName { get; set; }

    [JsonPropertyName("cveSeverityInformation")]
    public WindowsUpdatesQualityUpdateCveSeverityInformationModel? CveSeverityInformation { get; set; }

    [JsonPropertyName("deployableUntilDateTime")]
    public DateTime? DeployableUntilDateTime { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isExpeditable")]
    public bool? IsExpeditable { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("productRevisions")]
    public List<WindowsUpdatesProductRevisionModel>? ProductRevisions { get; set; }

    [JsonPropertyName("qualityUpdateCadence")]
    public WindowsUpdatesQualityUpdateCatalogEntryQualityUpdateCadenceConstant? QualityUpdateCadence { get; set; }

    [JsonPropertyName("qualityUpdateClassification")]
    public WindowsUpdatesQualityUpdateCatalogEntryQualityUpdateClassificationConstant? QualityUpdateClassification { get; set; }

    [JsonPropertyName("releaseDateTime")]
    public DateTime? ReleaseDateTime { get; set; }

    [JsonPropertyName("shortName")]
    public string? ShortName { get; set; }
}
