using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_12_01.AppPlatform;


internal class ApplicationAcceleratorComponentModel
{
    [JsonPropertyName("instances")]
    public List<ApplicationAcceleratorInstanceModel>? Instances { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("resourceRequests")]
    public ApplicationAcceleratorResourceRequestsModel? ResourceRequests { get; set; }
}
