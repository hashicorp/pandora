// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SynchronizationTaskExecutionModel
{
    [JsonPropertyName("activityIdentifier")]
    public string? ActivityIdentifier { get; set; }

    [JsonPropertyName("countEntitled")]
    public long? CountEntitled { get; set; }

    [JsonPropertyName("countEntitledForProvisioning")]
    public long? CountEntitledForProvisioning { get; set; }

    [JsonPropertyName("countEscrowed")]
    public long? CountEscrowed { get; set; }

    [JsonPropertyName("countEscrowedRaw")]
    public long? CountEscrowedRaw { get; set; }

    [JsonPropertyName("countExported")]
    public long? CountExported { get; set; }

    [JsonPropertyName("countExports")]
    public long? CountExports { get; set; }

    [JsonPropertyName("countImported")]
    public long? CountImported { get; set; }

    [JsonPropertyName("countImportedDeltas")]
    public long? CountImportedDeltas { get; set; }

    [JsonPropertyName("countImportedReferenceDeltas")]
    public long? CountImportedReferenceDeltas { get; set; }

    [JsonPropertyName("error")]
    public SynchronizationErrorModel? Error { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("state")]
    public SynchronizationTaskExecutionResultConstant? State { get; set; }

    [JsonPropertyName("timeBegan")]
    public DateTime? TimeBegan { get; set; }

    [JsonPropertyName("timeEnded")]
    public DateTime? TimeEnded { get; set; }
}
