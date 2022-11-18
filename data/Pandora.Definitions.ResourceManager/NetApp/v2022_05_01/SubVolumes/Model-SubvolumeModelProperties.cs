using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2022_05_01.SubVolumes;


internal class SubvolumeModelPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("accessedTimeStamp")]
    public DateTime? AccessedTimeStamp { get; set; }

    [JsonPropertyName("bytesUsed")]
    public int? BytesUsed { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("changedTimeStamp")]
    public DateTime? ChangedTimeStamp { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationTimeStamp")]
    public DateTime? CreationTimeStamp { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("modifiedTimeStamp")]
    public DateTime? ModifiedTimeStamp { get; set; }

    [JsonPropertyName("parentPath")]
    public string? ParentPath { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [JsonPropertyName("permissions")]
    public string? Permissions { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }
}
