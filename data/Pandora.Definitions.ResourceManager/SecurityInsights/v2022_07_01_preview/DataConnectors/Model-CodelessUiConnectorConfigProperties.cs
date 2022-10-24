using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.DataConnectors;


internal class CodelessUiConnectorConfigPropertiesModel
{
    [JsonPropertyName("availability")]
    [Required]
    public AvailabilityModel Availability { get; set; }

    [JsonPropertyName("connectivityCriteria")]
    [Required]
    public List<ConnectivityCriteriaModel> ConnectivityCriteria { get; set; }

    [JsonPropertyName("customImage")]
    public string? CustomImage { get; set; }

    [JsonPropertyName("dataTypes")]
    [Required]
    public List<LastDataReceivedDataTypeModel> DataTypes { get; set; }

    [JsonPropertyName("descriptionMarkdown")]
    [Required]
    public string DescriptionMarkdown { get; set; }

    [JsonPropertyName("graphQueries")]
    [Required]
    public List<GraphQueriesModel> GraphQueries { get; set; }

    [JsonPropertyName("graphQueriesTableName")]
    [Required]
    public string GraphQueriesTableName { get; set; }

    [JsonPropertyName("instructionSteps")]
    [Required]
    public List<InstructionStepsModel> InstructionSteps { get; set; }

    [JsonPropertyName("permissions")]
    [Required]
    public PermissionsModel Permissions { get; set; }

    [JsonPropertyName("publisher")]
    [Required]
    public string Publisher { get; set; }

    [JsonPropertyName("sampleQueries")]
    [Required]
    public List<SampleQueriesModel> SampleQueries { get; set; }

    [JsonPropertyName("title")]
    [Required]
    public string Title { get; set; }
}
