using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.SupportedOperatingSystems;


internal class OSVersionWrapperModel
{
    [JsonPropertyName("servicePack")]
    public string? ServicePack { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
