using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview.Tasks;


internal class BaseImageTriggerUpdateParametersModel
{
    [JsonPropertyName("baseImageTriggerType")]
    public BaseImageTriggerTypeConstant? BaseImageTriggerType { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("status")]
    public TriggerStatusConstant? Status { get; set; }

    [JsonPropertyName("updateTriggerEndpoint")]
    public string? UpdateTriggerEndpoint { get; set; }

    [JsonPropertyName("updateTriggerPayloadType")]
    public UpdateTriggerPayloadTypeConstant? UpdateTriggerPayloadType { get; set; }
}
