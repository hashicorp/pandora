// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SynchronizationTaskExecutionModel
{
    [JsonPropertyName("activityIdentifier")]
    public string? ActivityIdentifier { get; set; }

    [JsonPropertyName("countEntitled")]
    public int? CountEntitled { get; set; }

    [JsonPropertyName("countEntitledForProvisioning")]
    public int? CountEntitledForProvisioning { get; set; }

    [JsonPropertyName("countEscrowed")]
    public int? CountEscrowed { get; set; }

    [JsonPropertyName("countEscrowedRaw")]
    public int? CountEscrowedRaw { get; set; }

    [JsonPropertyName("countExported")]
    public int? CountExported { get; set; }

    [JsonPropertyName("countExports")]
    public int? CountExports { get; set; }

    [JsonPropertyName("countImported")]
    public int? CountImported { get; set; }

    [JsonPropertyName("countImportedDeltas")]
    public int? CountImportedDeltas { get; set; }

    [JsonPropertyName("countImportedReferenceDeltas")]
    public int? CountImportedReferenceDeltas { get; set; }

    [JsonPropertyName("error")]
    public SynchronizationErrorModel? Error { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("state")]
    public SynchronizationTaskExecutionStateConstant? State { get; set; }

    [JsonPropertyName("timeBegan")]
    public DateTime? TimeBegan { get; set; }

    [JsonPropertyName("timeEnded")]
    public DateTime? TimeEnded { get; set; }
}
