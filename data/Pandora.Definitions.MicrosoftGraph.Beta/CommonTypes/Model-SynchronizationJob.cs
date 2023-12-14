// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SynchronizationJobModel
{
    [JsonPropertyName("bulkUpload")]
    public BulkUploadModel? BulkUpload { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("schedule")]
    public SynchronizationScheduleModel? Schedule { get; set; }

    [JsonPropertyName("schema")]
    public SynchronizationSchemaModel? Schema { get; set; }

    [JsonPropertyName("status")]
    public SynchronizationStatusModel? Status { get; set; }

    [JsonPropertyName("synchronizationJobSettings")]
    public List<KeyValuePairModel>? SynchronizationJobSettings { get; set; }

    [JsonPropertyName("templateId")]
    public string? TemplateId { get; set; }
}
