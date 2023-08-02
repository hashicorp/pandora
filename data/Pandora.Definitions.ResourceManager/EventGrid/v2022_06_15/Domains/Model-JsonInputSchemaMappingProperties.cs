using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.Domains;


internal class JsonInputSchemaMappingPropertiesModel
{
    [JsonPropertyName("dataVersion")]
    public JsonFieldWithDefaultModel? DataVersion { get; set; }

    [JsonPropertyName("eventTime")]
    public JsonFieldModel? EventTime { get; set; }

    [JsonPropertyName("eventType")]
    public JsonFieldWithDefaultModel? EventType { get; set; }

    [JsonPropertyName("id")]
    public JsonFieldModel? Id { get; set; }

    [JsonPropertyName("subject")]
    public JsonFieldWithDefaultModel? Subject { get; set; }

    [JsonPropertyName("topic")]
    public JsonFieldModel? Topic { get; set; }
}
