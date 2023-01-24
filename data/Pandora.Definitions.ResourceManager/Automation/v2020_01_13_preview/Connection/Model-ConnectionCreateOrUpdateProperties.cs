using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2020_01_13_preview.Connection;


internal class ConnectionCreateOrUpdatePropertiesModel
{
    [JsonPropertyName("connectionType")]
    [Required]
    public ConnectionTypeAssociationPropertyModel ConnectionType { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("fieldDefinitionValues")]
    public Dictionary<string, string>? FieldDefinitionValues { get; set; }
}
