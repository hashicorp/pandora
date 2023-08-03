// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ExternalConnectorsExternalItemModel
{
    [JsonPropertyName("acl")]
    public List<AclModel>? Acl { get; set; }

    [JsonPropertyName("activities")]
    public List<ExternalActivityModel>? Activities { get; set; }

    [JsonPropertyName("content")]
    public ExternalItemContentModel? Content { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("properties")]
    public PropertiesModel? Properties { get; set; }
}
