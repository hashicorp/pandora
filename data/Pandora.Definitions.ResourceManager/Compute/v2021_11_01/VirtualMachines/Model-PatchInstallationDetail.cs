using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachines;


internal class PatchInstallationDetailModel
{
    [JsonPropertyName("classifications")]
    public List<string>? Classifications { get; set; }

    [JsonPropertyName("installationState")]
    public PatchInstallationStateConstant? InstallationState { get; set; }

    [JsonPropertyName("kbId")]
    public string? KbId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("patchId")]
    public string? PatchId { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
