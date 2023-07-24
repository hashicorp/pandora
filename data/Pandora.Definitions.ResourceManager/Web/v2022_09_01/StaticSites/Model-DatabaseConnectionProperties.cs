using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.StaticSites;


internal class DatabaseConnectionPropertiesModel
{
    [JsonPropertyName("configurationFiles")]
    public List<StaticSiteDatabaseConnectionConfigurationFileOverviewModel>? ConfigurationFiles { get; set; }

    [JsonPropertyName("connectionIdentity")]
    public string? ConnectionIdentity { get; set; }

    [JsonPropertyName("connectionString")]
    public string? ConnectionString { get; set; }

    [JsonPropertyName("region")]
    [Required]
    public string Region { get; set; }

    [JsonPropertyName("resourceId")]
    [Required]
    public string ResourceId { get; set; }
}
