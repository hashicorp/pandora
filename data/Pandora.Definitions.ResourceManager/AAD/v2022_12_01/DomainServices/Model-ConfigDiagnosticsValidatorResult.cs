using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AAD.v2022_12_01.DomainServices;


internal class ConfigDiagnosticsValidatorResultModel
{
    [JsonPropertyName("issues")]
    public List<ConfigDiagnosticsValidatorResultIssueModel>? Issues { get; set; }

    [JsonPropertyName("replicaSetSubnetDisplayName")]
    public string? ReplicaSetSubnetDisplayName { get; set; }

    [JsonPropertyName("status")]
    public StatusConstant? Status { get; set; }

    [JsonPropertyName("validatorId")]
    public string? ValidatorId { get; set; }
}
