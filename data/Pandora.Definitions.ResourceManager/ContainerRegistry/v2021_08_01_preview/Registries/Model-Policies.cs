using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_08_01_preview.Registries;


internal class PoliciesModel
{
    [JsonPropertyName("exportPolicy")]
    public ExportPolicyModel? ExportPolicy { get; set; }

    [JsonPropertyName("quarantinePolicy")]
    public QuarantinePolicyModel? QuarantinePolicy { get; set; }

    [JsonPropertyName("retentionPolicy")]
    public RetentionPolicyModel? RetentionPolicy { get; set; }

    [JsonPropertyName("trustPolicy")]
    public TrustPolicyModel? TrustPolicy { get; set; }
}
