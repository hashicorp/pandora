// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceLocalCredentialModel
{
    [JsonPropertyName("accountName")]
    public string? AccountName { get; set; }

    [JsonPropertyName("accountSid")]
    public string? AccountSid { get; set; }

    [JsonPropertyName("backupDateTime")]
    public DateTime? BackupDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("passwordBase64")]
    public string? PasswordBase64 { get; set; }
}
