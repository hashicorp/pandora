using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.RegistryManagement;


internal class SystemCreatedAcrAccountModel
{
    [JsonPropertyName("acrAccountName")]
    public string? AcrAccountName { get; set; }

    [JsonPropertyName("acrAccountSku")]
    public string? AcrAccountSku { get; set; }

    [JsonPropertyName("armResourceId")]
    public ArmResourceIdModel? ArmResourceId { get; set; }
}
