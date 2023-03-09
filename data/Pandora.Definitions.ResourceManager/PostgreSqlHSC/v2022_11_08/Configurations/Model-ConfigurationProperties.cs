using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSqlHSC.v2022_11_08.Configurations;


internal class ConfigurationPropertiesModel
{
    [JsonPropertyName("allowedValues")]
    public string? AllowedValues { get; set; }

    [JsonPropertyName("dataType")]
    public ConfigurationDataTypeConstant? DataType { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("requiresRestart")]
    public bool? RequiresRestart { get; set; }

    [JsonPropertyName("serverRoleGroupConfigurations")]
    [Required]
    public List<ServerRoleGroupConfigurationModel> ServerRoleGroupConfigurations { get; set; }
}
