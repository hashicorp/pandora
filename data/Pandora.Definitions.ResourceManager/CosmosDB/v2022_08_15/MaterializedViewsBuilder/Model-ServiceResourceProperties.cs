using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_08_15.MaterializedViewsBuilder;


internal abstract class ServiceResourcePropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationTime")]
    public DateTime? CreationTime { get; set; }

    [JsonPropertyName("instanceCount")]
    public int? InstanceCount { get; set; }

    [JsonPropertyName("instanceSize")]
    public ServiceSizeConstant? InstanceSize { get; set; }

    [JsonPropertyName("serviceType")]
    [ProvidesTypeHint]
    [Required]
    public ServiceTypeConstant ServiceType { get; set; }

    [JsonPropertyName("status")]
    public ServiceStatusConstant? Status { get; set; }
}
