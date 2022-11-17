using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.SessionHost;


internal class SessionHostHealthCheckFailureDetailsModel
{
    [JsonPropertyName("errorCode")]
    public int? ErrorCode { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastHealthCheckDateTime")]
    public DateTime? LastHealthCheckDateTime { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}
