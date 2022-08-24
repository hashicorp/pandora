using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.MaterializedViewsBuilder;


internal class ServiceResourceCreateUpdatePropertiesModel
{
    [JsonPropertyName("instanceCount")]
    public int? InstanceCount { get; set; }

    [JsonPropertyName("instanceSize")]
    public ServiceSizeConstant? InstanceSize { get; set; }

    [JsonPropertyName("serviceType")]
    public ServiceTypeConstant? ServiceType { get; set; }
}
