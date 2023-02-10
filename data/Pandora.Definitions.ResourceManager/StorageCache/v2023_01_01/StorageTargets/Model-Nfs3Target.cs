using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageCache.v2023_01_01.StorageTargets;


internal class Nfs3TargetModel
{
    [JsonPropertyName("target")]
    public string? Target { get; set; }

    [JsonPropertyName("usageModel")]
    public string? UsageModel { get; set; }

    [JsonPropertyName("verificationTimer")]
    public int? VerificationTimer { get; set; }

    [JsonPropertyName("writeBackTimer")]
    public int? WriteBackTimer { get; set; }
}
