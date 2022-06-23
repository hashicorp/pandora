using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.DataConnectors;


internal class AwsS3DataConnectorPropertiesModel
{
    [JsonPropertyName("dataTypes")]
    [Required]
    public AwsS3DataConnectorDataTypesModel DataTypes { get; set; }

    [JsonPropertyName("destinationTable")]
    [Required]
    public string DestinationTable { get; set; }

    [JsonPropertyName("roleArn")]
    [Required]
    public string RoleArn { get; set; }

    [JsonPropertyName("sqsUrls")]
    [Required]
    public List<string> SqsUrls { get; set; }
}
