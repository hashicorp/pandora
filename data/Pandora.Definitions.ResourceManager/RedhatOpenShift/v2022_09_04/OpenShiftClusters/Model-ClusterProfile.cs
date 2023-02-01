using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RedhatOpenShift.v2022_09_04.OpenShiftClusters;


internal class ClusterProfileModel
{
    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    [JsonPropertyName("fipsValidatedModules")]
    public FipsValidatedModulesConstant? FipsValidatedModules { get; set; }

    [JsonPropertyName("pullSecret")]
    public string? PullSecret { get; set; }

    [JsonPropertyName("resourceGroupId")]
    public string? ResourceGroupId { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
