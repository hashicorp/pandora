// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ExternalConnectorsExternalConnectionModel
{
    [JsonPropertyName("activitySettings")]
    public ExternalConnectorsActivitySettingsModel? ActivitySettings { get; set; }

    [JsonPropertyName("complianceSettings")]
    public ExternalConnectorsComplianceSettingsModel? ComplianceSettings { get; set; }

    [JsonPropertyName("configuration")]
    public ExternalConnectorsConfigurationModel? Configuration { get; set; }

    [JsonPropertyName("connectorId")]
    public string? ConnectorId { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("enabledContentExperiences")]
    public ExternalConnectorsExternalConnectionEnabledContentExperiencesConstant? EnabledContentExperiences { get; set; }

    [JsonPropertyName("groups")]
    public List<ExternalConnectorsExternalGroupModel>? Groups { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("ingestedItemsCount")]
    public int? IngestedItemsCount { get; set; }

    [JsonPropertyName("items")]
    public List<ExternalConnectorsExternalItemModel>? Items { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operations")]
    public List<ExternalConnectorsConnectionOperationModel>? Operations { get; set; }

    [JsonPropertyName("quota")]
    public ExternalConnectorsConnectionQuotaModel? Quota { get; set; }

    [JsonPropertyName("schema")]
    public ExternalConnectorsSchemaModel? Schema { get; set; }

    [JsonPropertyName("searchSettings")]
    public ExternalConnectorsSearchSettingsModel? SearchSettings { get; set; }

    [JsonPropertyName("state")]
    public ExternalConnectorsExternalConnectionStateConstant? State { get; set; }
}
