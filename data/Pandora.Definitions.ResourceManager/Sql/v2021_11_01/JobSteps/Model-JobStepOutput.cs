using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.JobSteps;


internal class JobStepOutputModel
{
    [JsonPropertyName("credential")]
    [Required]
    public string Credential { get; set; }

    [JsonPropertyName("databaseName")]
    [Required]
    public string DatabaseName { get; set; }

    [JsonPropertyName("resourceGroupName")]
    public string? ResourceGroupName { get; set; }

    [JsonPropertyName("schemaName")]
    public string? SchemaName { get; set; }

    [JsonPropertyName("serverName")]
    [Required]
    public string ServerName { get; set; }

    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }

    [JsonPropertyName("tableName")]
    [Required]
    public string TableName { get; set; }

    [JsonPropertyName("type")]
    public JobStepOutputTypeConstant? Type { get; set; }
}
