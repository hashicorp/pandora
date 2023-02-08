using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2015_10_31.Module;


internal class ModulePropertiesModel
{
    [JsonPropertyName("activityCount")]
    public int? ActivityCount { get; set; }

    [JsonPropertyName("contentLink")]
    public ContentLinkModel? ContentLink { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationTime")]
    public DateTime? CreationTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("error")]
    public ModuleErrorInfoModel? Error { get; set; }

    [JsonPropertyName("isComposite")]
    public bool? IsComposite { get; set; }

    [JsonPropertyName("isGlobal")]
    public bool? IsGlobal { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedTime")]
    public DateTime? LastModifiedTime { get; set; }

    [JsonPropertyName("provisioningState")]
    public ModuleProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("sizeInBytes")]
    public int? SizeInBytes { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
