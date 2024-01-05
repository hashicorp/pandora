using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_12_01.AppPlatform;

[ValueForType("War")]
internal class WarUploadedUserSourceInfoModel : UserSourceInfoModel
{
    [JsonPropertyName("jvmOptions")]
    public string? JVMOptions { get; set; }

    [JsonPropertyName("relativePath")]
    public string? RelativePath { get; set; }

    [JsonPropertyName("runtimeVersion")]
    public string? RuntimeVersion { get; set; }

    [JsonPropertyName("serverVersion")]
    public string? ServerVersion { get; set; }
}
