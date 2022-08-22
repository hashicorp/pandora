using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.ApisByTag;


internal class TagResourceContractModel
{
    [JsonPropertyName("api")]
    public ApiTagResourceContractPropertiesModel? Api { get; set; }

    [JsonPropertyName("operation")]
    public OperationTagResourceContractPropertiesModel? Operation { get; set; }

    [JsonPropertyName("product")]
    public ProductTagResourceContractPropertiesModel? Product { get; set; }

    [JsonPropertyName("tag")]
    [Required]
    public TagTagResourceContractPropertiesModel Tag { get; set; }
}
