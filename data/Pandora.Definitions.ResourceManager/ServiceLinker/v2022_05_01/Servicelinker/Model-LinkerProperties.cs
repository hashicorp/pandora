using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceLinker.v2022_05_01.Servicelinker;


internal class LinkerPropertiesModel
{
    [JsonPropertyName("authInfo")]
    public AuthInfoBaseModel? AuthInfo { get; set; }

    [JsonPropertyName("clientType")]
    public ClientTypeConstant? ClientType { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    [JsonPropertyName("secretStore")]
    public SecretStoreModel? SecretStore { get; set; }

    [JsonPropertyName("targetService")]
    public TargetServiceBaseModel? TargetService { get; set; }

    [JsonPropertyName("vNetSolution")]
    public VNetSolutionModel? VNetSolution { get; set; }
}
