using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_12_01.BackupInstances;


internal class UserFacingErrorModel
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("details")]
    public List<UserFacingErrorModel>? Details { get; set; }

    [JsonPropertyName("innerError")]
    public InnerErrorModel? InnerError { get; set; }

    [JsonPropertyName("isRetryable")]
    public bool? IsRetryable { get; set; }

    [JsonPropertyName("isUserError")]
    public bool? IsUserError { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("properties")]
    public Dictionary<string, string>? Properties { get; set; }

    [JsonPropertyName("recommendedAction")]
    public List<string>? RecommendedAction { get; set; }

    [JsonPropertyName("target")]
    public string? Target { get; set; }
}
