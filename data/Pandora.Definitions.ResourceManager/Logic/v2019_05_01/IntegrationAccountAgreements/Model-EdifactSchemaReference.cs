using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;


internal class EdifactSchemaReferenceModel
{
    [JsonPropertyName("associationAssignedCode")]
    public string? AssociationAssignedCode { get; set; }

    [JsonPropertyName("messageId")]
    [Required]
    public string MessageId { get; set; }

    [JsonPropertyName("messageRelease")]
    [Required]
    public string MessageRelease { get; set; }

    [JsonPropertyName("messageVersion")]
    [Required]
    public string MessageVersion { get; set; }

    [JsonPropertyName("schemaName")]
    [Required]
    public string SchemaName { get; set; }

    [JsonPropertyName("senderApplicationId")]
    public string? SenderApplicationId { get; set; }

    [JsonPropertyName("senderApplicationQualifier")]
    public string? SenderApplicationQualifier { get; set; }
}
