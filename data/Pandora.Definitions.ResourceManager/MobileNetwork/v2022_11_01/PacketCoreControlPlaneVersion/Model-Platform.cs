using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.PacketCoreControlPlaneVersion;


internal class PlatformModel
{
    [JsonPropertyName("maximumPlatformSoftwareVersion")]
    public string? MaximumPlatformSoftwareVersion { get; set; }

    [JsonPropertyName("minimumPlatformSoftwareVersion")]
    public string? MinimumPlatformSoftwareVersion { get; set; }

    [JsonPropertyName("obsoleteVersion")]
    public ObsoleteVersionConstant? ObsoleteVersion { get; set; }

    [JsonPropertyName("platformType")]
    public PlatformTypeConstant? PlatformType { get; set; }

    [JsonPropertyName("recommendedVersion")]
    public RecommendedVersionConstant? RecommendedVersion { get; set; }

    [JsonPropertyName("versionState")]
    public VersionStateConstant? VersionState { get; set; }
}
