using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationsManagement.v2015_11_01_preview.ManagementConfiguration;


internal class ManagementConfigurationPropertiesModel
{
    [JsonPropertyName("applicationId")]
    public string? ApplicationId { get; set; }

    [JsonPropertyName("parameters")]
    [Required]
    public List<ArmTemplateParameterModel> Parameters { get; set; }

    [JsonPropertyName("parentResourceType")]
    [Required]
    public string ParentResourceType { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("template")]
    [Required]
    public object Template { get; set; }
}
