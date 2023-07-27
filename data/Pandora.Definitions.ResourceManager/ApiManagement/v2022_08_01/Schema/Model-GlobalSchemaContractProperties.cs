using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.Schema;


internal class GlobalSchemaContractPropertiesModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("document")]
    public object? Document { get; set; }

    [JsonPropertyName("schemaType")]
    [Required]
    public SchemaTypeConstant SchemaType { get; set; }

    [JsonPropertyName("value")]
    public object? Value { get; set; }
}
