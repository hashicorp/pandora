using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataMigration.v2021_06_30.StandardOperation;


internal class ProjectPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationTime")]
    public DateTime? CreationTime { get; set; }

    [JsonPropertyName("databasesInfo")]
    public List<DatabaseInfoModel>? DatabasesInfo { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProjectProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("sourceConnectionInfo")]
    public ConnectionInfoModel? SourceConnectionInfo { get; set; }

    [JsonPropertyName("sourcePlatform")]
    [Required]
    public ProjectSourcePlatformConstant SourcePlatform { get; set; }

    [JsonPropertyName("targetConnectionInfo")]
    public ConnectionInfoModel? TargetConnectionInfo { get; set; }

    [JsonPropertyName("targetPlatform")]
    [Required]
    public ProjectTargetPlatformConstant TargetPlatform { get; set; }
}
