using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.NetworkSecurityGroups;


internal class DdosSettingsModel
{
    [JsonPropertyName("ddosCustomPolicy")]
    public SubResourceModel? DdosCustomPolicy { get; set; }

    [JsonPropertyName("protectedIP")]
    public bool? ProtectedIP { get; set; }

    [JsonPropertyName("protectionCoverage")]
    public DdosSettingsProtectionCoverageConstant? ProtectionCoverage { get; set; }
}
