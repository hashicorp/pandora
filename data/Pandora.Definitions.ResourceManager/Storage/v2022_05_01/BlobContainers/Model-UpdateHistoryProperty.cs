using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.BlobContainers;


internal class UpdateHistoryPropertyModel
{
    [JsonPropertyName("allowProtectedAppendWrites")]
    public bool? AllowProtectedAppendWrites { get; set; }

    [JsonPropertyName("allowProtectedAppendWritesAll")]
    public bool? AllowProtectedAppendWritesAll { get; set; }

    [JsonPropertyName("immutabilityPeriodSinceCreationInDays")]
    public int? ImmutabilityPeriodSinceCreationInDays { get; set; }

    [JsonPropertyName("objectIdentifier")]
    public string? ObjectIdentifier { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timestamp")]
    public DateTime? Timestamp { get; set; }

    [JsonPropertyName("update")]
    public ImmutabilityPolicyUpdateTypeConstant? Update { get; set; }

    [JsonPropertyName("upn")]
    public string? Upn { get; set; }
}
