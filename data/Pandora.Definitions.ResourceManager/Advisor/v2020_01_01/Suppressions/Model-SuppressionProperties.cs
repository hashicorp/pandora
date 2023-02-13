using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Advisor.v2020_01_01.Suppressions;


internal class SuppressionPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expirationTimeStamp")]
    public DateTime? ExpirationTimeStamp { get; set; }

    [JsonPropertyName("suppressionId")]
    public string? SuppressionId { get; set; }

    [JsonPropertyName("ttl")]
    public string? Ttl { get; set; }
}
