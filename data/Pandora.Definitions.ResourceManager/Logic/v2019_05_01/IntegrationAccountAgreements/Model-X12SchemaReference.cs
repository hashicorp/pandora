using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;


internal class X12SchemaReferenceModel
{
    [JsonPropertyName("messageId")]
    [Required]
    public string MessageId { get; set; }

    [JsonPropertyName("schemaName")]
    [Required]
    public string SchemaName { get; set; }

    [JsonPropertyName("schemaVersion")]
    [Required]
    public string SchemaVersion { get; set; }

    [JsonPropertyName("senderApplicationId")]
    public string? SenderApplicationId { get; set; }
}
