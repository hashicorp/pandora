using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.NetworkWatchers;


internal class NetworkConfigurationDiagnosticParametersModel
{
    [JsonPropertyName("profiles")]
    [Required]
    public List<NetworkConfigurationDiagnosticProfileModel> Profiles { get; set; }

    [JsonPropertyName("targetResourceId")]
    [Required]
    public string TargetResourceId { get; set; }

    [JsonPropertyName("verbosityLevel")]
    public VerbosityLevelConstant? VerbosityLevel { get; set; }
}
