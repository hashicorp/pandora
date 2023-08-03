// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class QuotaModel
{
    [JsonPropertyName("deleted")]
    public long? Deleted { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("remaining")]
    public long? Remaining { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("storagePlanInformation")]
    public StoragePlanInformationModel? StoragePlanInformation { get; set; }

    [JsonPropertyName("total")]
    public long? Total { get; set; }

    [JsonPropertyName("used")]
    public long? Used { get; set; }
}
