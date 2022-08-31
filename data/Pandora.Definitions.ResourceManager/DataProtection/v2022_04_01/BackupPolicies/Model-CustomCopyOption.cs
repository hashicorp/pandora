using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_04_01.BackupPolicies;

[ValueForType("CustomCopyOption")]
internal class CustomCopyOptionModel : CopyOptionModel
{
    [JsonPropertyName("duration")]
    public string? Duration { get; set; }
}
