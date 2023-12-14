using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2024_01_01.Pricings;


internal class ExtensionModel
{
    [JsonPropertyName("additionalExtensionProperties")]
    public object? AdditionalExtensionProperties { get; set; }

    [JsonPropertyName("isEnabled")]
    [Required]
    public IsEnabledConstant IsEnabled { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("operationStatus")]
    public OperationStatusModel? OperationStatus { get; set; }
}
