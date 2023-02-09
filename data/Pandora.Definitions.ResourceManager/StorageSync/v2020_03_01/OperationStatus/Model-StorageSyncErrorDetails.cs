using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.OperationStatus;


internal class StorageSyncErrorDetailsModel
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("exceptionType")]
    public string? ExceptionType { get; set; }

    [JsonPropertyName("httpErrorCode")]
    public string? HTTPErrorCode { get; set; }

    [JsonPropertyName("httpMethod")]
    public string? HTTPMethod { get; set; }

    [JsonPropertyName("hashedMessage")]
    public string? HashedMessage { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("requestUri")]
    public string? RequestUri { get; set; }

    [JsonPropertyName("target")]
    public string? Target { get; set; }
}
