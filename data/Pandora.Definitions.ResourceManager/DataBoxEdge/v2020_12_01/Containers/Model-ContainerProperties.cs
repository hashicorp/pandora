using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Containers;


internal class ContainerPropertiesModel
{
    [JsonPropertyName("containerStatus")]
    public ContainerStatusConstant? ContainerStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("dataFormat")]
    [Required]
    public AzureContainerDataFormatConstant DataFormat { get; set; }

    [JsonPropertyName("refreshDetails")]
    public RefreshDetailsModel? RefreshDetails { get; set; }
}
