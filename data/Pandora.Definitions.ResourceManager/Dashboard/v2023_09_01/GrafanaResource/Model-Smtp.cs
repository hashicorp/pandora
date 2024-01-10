using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Dashboard.v2023_09_01.GrafanaResource;


internal class SmtpModel
{
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("fromAddress")]
    public string? FromAddress { get; set; }

    [JsonPropertyName("fromName")]
    public string? FromName { get; set; }

    [JsonPropertyName("host")]
    public string? Host { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("skipVerify")]
    public bool? SkipVerify { get; set; }

    [JsonPropertyName("startTLSPolicy")]
    public StartTLSPolicyConstant? StartTLSPolicy { get; set; }

    [JsonPropertyName("user")]
    public string? User { get; set; }
}
