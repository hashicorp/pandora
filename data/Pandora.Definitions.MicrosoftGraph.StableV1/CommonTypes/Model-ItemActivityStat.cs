// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ItemActivityStatModel
{
    [JsonPropertyName("access")]
    public ItemActionStatModel? Access { get; set; }

    [JsonPropertyName("activities")]
    public List<ItemActivityModel>? Activities { get; set; }

    [JsonPropertyName("create")]
    public ItemActionStatModel? Create { get; set; }

    [JsonPropertyName("delete")]
    public ItemActionStatModel? Delete { get; set; }

    [JsonPropertyName("edit")]
    public ItemActionStatModel? Edit { get; set; }

    [JsonPropertyName("endDateTime")]
    public DateTime? EndDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("incompleteData")]
    public IncompleteDataModel? IncompleteData { get; set; }

    [JsonPropertyName("isTrending")]
    public bool? IsTrending { get; set; }

    [JsonPropertyName("move")]
    public ItemActionStatModel? Move { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }
}
