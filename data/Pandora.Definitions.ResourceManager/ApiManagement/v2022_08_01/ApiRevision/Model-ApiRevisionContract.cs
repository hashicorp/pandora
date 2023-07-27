using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.ApiRevision;


internal class ApiRevisionContractModel
{
    [JsonPropertyName("apiId")]
    public string? ApiId { get; set; }

    [JsonPropertyName("apiRevision")]
    public string? ApiRevision { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("isCurrent")]
    public bool? IsCurrent { get; set; }

    [JsonPropertyName("isOnline")]
    public bool? IsOnline { get; set; }

    [JsonPropertyName("privateUrl")]
    public string? PrivateUrl { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("updatedDateTime")]
    public DateTime? UpdatedDateTime { get; set; }
}
